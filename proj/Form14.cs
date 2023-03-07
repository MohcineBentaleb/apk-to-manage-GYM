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
namespace proj
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public void replisageDGV()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From coach";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt;
            cnx.Close();
        }
        public void restart()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From coach ";
            SqlDataAdapter WAC = new SqlDataAdapter(cmd);
            SqlCommandBuilder bb = new SqlCommandBuilder();
            var ds = new DataSet();
            WAC.Fill(ds);
            bunifuCustomDataGrid1.DataSource = ds.Tables[0];
            cnx.Close();
        }
        private void Créer_Click(object sender, EventArgs e)
        {
            
            Form17 f = new Form17();
            this.Hide();
            f.Show();

            

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
           
            Form18 f = new Form18();
            this.Hide();
            FF.Show();
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            
            
            
        }
        public static string h = string.Empty;
        private void Form14_Load(object sender, EventArgs e)
        {
            replisageDGV();
            restart();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        { Form3 f = new Form3();
            f.Show();
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            cnx.Open();
            if (dt.Rows != null)
            {
                dt.Clear();
            }
            SqlCommand cmd = new SqlCommand("select * from coach where IDcoach=@c", cnx);
            cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt;
            cnx.Close();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            restart();
        }
        public Form18 FF = new Form18();
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                //gets a collection that contains all the rows
                DataGridViewRow row = this.bunifuCustomDataGrid1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                FF.bunifuMaterialTextbox1.Text = row.Cells[0].Value.ToString();
                FF.bunifuMaterialTextbox4.Text = row.Cells[1].Value.ToString();                
                FF.comboBox2.Text = row.Cells[2].Value.ToString();
                FF.comboBox3.Text = row.Cells[3].Value.ToString();
                FF.comboBox1.Text = row.Cells[4].Value.ToString();

            }
        }
    }
}
