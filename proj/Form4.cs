using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlClient;

namespace proj
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            //this.label4.Text = n;
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        
        //public static string pk( 

        //    )
        
        public void replisageDGV()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From Clients";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt;
            cnx.Close();
        }
        public void restart()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From Clients";
            SqlDataAdapter WAC = new SqlDataAdapter(cmd);
            SqlCommandBuilder bb = new SqlCommandBuilder();
            var ds = new DataSet();
            WAC.Fill(ds);
            bunifuCustomDataGrid1.DataSource = ds.Tables[0];
            cnx.Close();
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            replisageDGV();
            restart();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            cnx.Open();
            if (dt.Rows != null)
            {
                dt.Clear();
            }
            SqlCommand cmd = new SqlCommand("select * from Clients where IdClient=@c", cnx);
            cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt;
             cnx.Close();

        }

        private void Créer_Click(object sender, EventArgs e)
        {
            Form5 f= new Form5();
            this.Hide();
            f.Show();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
          
            Form3 f = new Form3();

            f.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            this.Hide();
            F.Show();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public Form7 F = new Form7();
        
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {

                //gets a collection that contains all the rows
                DataGridViewRow row = this.bunifuCustomDataGrid1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                F.bunifuMaterialTextbox1.Text = row.Cells[0].Value.ToString();
                F.bunifuMaterialTextbox2.Text = row.Cells[1].Value.ToString();
                F.bunifuMaterialTextbox3.Text = row.Cells[2].Value.ToString();
                F.bunifuMaterialTextbox4.Text = row.Cells[3].Value.ToString();
                F.bunifuDatepicker1.Text = row.Cells[4].Value.ToString();
                F.comboBox1.Text = row.Cells[5].Value.ToString();

            }
            


        }

        private void bunifuCustomDataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
