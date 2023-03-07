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
    public partial class Form15 : Form
    {
        public Form15()
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
            cmd.CommandText = "select * From utilisateurs";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt;
            cnx.Close();
        }
        public void restart()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From utilisateurs";
            SqlDataAdapter WAC = new SqlDataAdapter(cmd);
            SqlCommandBuilder bb = new SqlCommandBuilder();
            var ds = new DataSet();
            WAC.Fill(ds);
            bunifuCustomDataGrid1.DataSource = ds.Tables[0];
            cnx.Close();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            replisageDGV();
            restart();
        }

        private void Créer_Click(object sender, EventArgs e)
        {
            Form24 f = new Form24();
            this.Hide();
            f.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            F.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string h = string.Empty;
            Form3 f = new Form3();
            this.Hide();
            f.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
            cnx.Open();
            if (dt.Rows != null)
            {
                dt.Clear();
            }
            SqlCommand cmd = new SqlCommand("select * from utilisateurs where utilisateur=@c", cnx);
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
        public Form25 F = new Form25();
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.bunifuCustomDataGrid1.Rows[e.RowIndex];              
                F.bunifuMaterialTextbox1.Text = row.Cells[0].Value.ToString();
                F.bunifuMaterialTextbox4.Text = row.Cells[1].Value.ToString();
                F.bunifuMaterialTextbox2.Text = row.Cells[2].Value.ToString();
                F.comboBox1.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
