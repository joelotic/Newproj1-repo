using System;
using System.Data;
using System.Windows.Forms;
using OOP_Interview.DataLayer;
using System.Data.OleDb;

namespace OOP_Interview
{
    public partial class Form1 : Form 
    {
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database DB = new Database();
            DB.OpenDBConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*ADD NEW RECORD*/
            Database db = new Database();
            db.OpenDBConnection();
            db.ExecuteQueries("INSERT INTO TABLE1(DW_OBJID,DW_OBJ_NAME) VALUES(NEWID(),'TEST 2')");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenDBConnection();
            OleDbDataReader rd =   db.ReadData("SELECT * FROM TABLE1 WHERE DW_OBJ_NAME='TEST 2' ");
            if (rd.Read())
            {
                label1.Text = rd["DW_OBJ_NAME"].ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenDBConnection();
            object rd =   db.ShowinGrid("SELECT * FROM TABLE1 order by dw_create_time  ");
            dataGridView1.DataSource = rd;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string valueID = dataGridView1.SelectedCells[0].Value.ToString();
            MessageBox.Show(valueID);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenDBConnection();

            object  ds = db.GetDataSetDiv();
            dataGridView1.DataSource = ds;
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenDBConnection();

            db.SP_AddRec(txtDivname.Text.Trim());
        }
    }
    
}
