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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public void combo()
        {
            string query = "select Nom from Clients";
            SqlCommand command = new SqlCommand(query, cnx);
            cnx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["Nom"].ToString());
            }
            cnx.Close();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            combo();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "" || bunifuMaterialTextbox3.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox1.Text == "")

            {
                MessageBox.Show("remplirer les champes");
            }
            else
            {
                cnx.Open();
            SqlCommand cmd = new SqlCommand("update Resu set Nom=@N,DateAbonnelent=@d,TypeAbonnelent=@t,Montant=@m,Mode=@mod where NumAbonnelent=@c", cnx);
            cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox2.Text);
            cmd.Parameters.AddWithValue("@N", comboBox3.Text);
            cmd.Parameters.AddWithValue("@d", Convert.ToDateTime(bunifuDatepicker1.Value));
            cmd.Parameters.AddWithValue("@t", comboBox2.Text);
            cmd.Parameters.AddWithValue("@m", bunifuMaterialTextbox3.Text);
            cmd.Parameters.AddWithValue("@mod", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("ok pour modification ");
            cnx.Close();
            this.Close();
            Form16 f = new Form16();
            f.Show();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
            Form16 f = new Form16();
            f.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
