using System;
using System.Data;

using System.Data.OleDb;
using System.Windows.Forms;

 
namespace OOP_Interview.DataLayer
{
    public class Database
    {
        string ConnectionString = "Provider=SQLOLEDB.1;Password=password;Persist Security Info=True;User ID=sa;Initial Catalog=testDB;Data Source=NB114JOEL\\SQLEXPRESS";
        OleDbConnection con;
        public void OpenDBConnection()
        {
            con = new OleDbConnection(ConnectionString);
            con.Open();
        }

        public void ExecuteQueries(string _query)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(_query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Add"); ;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public OleDbDataReader ReadData(string _query)
        {

            OleDbCommand cmd = new OleDbCommand(_query, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public Object ShowinGrid(string _query)
        {

            OleDbDataAdapter da = new OleDbDataAdapter(_query, ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];

        }

        public object  GetDataSetDiv()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("GetDivision", ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@iResult", "1");
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];

        }
        public void SP_AddRec(string sDivName)
        {
            OleDbCommand cmd = new OleDbCommand("AddDivisionName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DivName", sDivName);
            cmd.Parameters.AddWithValue("@iResult", "1");
            cmd.ExecuteNonQuery();
        
        }
        //static public String DBConnectionString
        //{
        //    get
        //    {    // get connection string with name  database from  web.config.
        //        //return WebConfigurationManager.ConnectionStrings["database"].ConnectionString;
        //        string ConnectionString = "";
        //        SqlConnection con;
        //        con = new SqlConnection(ConnectionString);
        //        con.Open();
        //    }
        //}
    }
}
