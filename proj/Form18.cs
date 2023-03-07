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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox4.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox1.Text == "")

            {
                MessageBox.Show("remplirer les champes", "problème de remplissage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnx.Open();
            SqlCommand cmd = new SqlCommand("update coach set Non_Prenom=@n,TypeSport=@t,Jours=@j,sex=@s where IDcoach=@i", cnx);
            cmd.Parameters.AddWithValue("@i", bunifuMaterialTextbox1.Text);
            cmd.Parameters.AddWithValue("@n", bunifuMaterialTextbox4.Text);
            cmd.Parameters.AddWithValue("@t", comboBox2.Text);
            cmd.Parameters.AddWithValue("@j", comboBox3.Text);
            cmd.Parameters.AddWithValue("@s", comboBox1.Text);
            cmd.ExecuteNonQuery();
            cnx.Close();
            this.Close();
            Form14 f = new Form14();
            f.Show();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
            Form14 f = new Form14();
            f.Show();
        }

        private void Form18_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")

            {
                MessageBox.Show("remplirer les champes", "problème de remplissage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("delete from coach where IDcoach=@c", cnx);
                cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();
                this.Close();
                Form14 f = new Form14();
                f.Show();
            }
        }
    }
}
