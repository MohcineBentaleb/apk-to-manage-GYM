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
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private void Form25_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox4.Text == "" || bunifuMaterialTextbox2.Text == "")

            {
                MessageBox.Show("remplirer les champes", "problème de remplissage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("update utilisateurs set Non_Prenom=@np,passwordd=@p where utilisateur=@u", cnx);
                cmd.Parameters.AddWithValue("@u ", bunifuMaterialTextbox1.Text);               
                cmd.Parameters.AddWithValue("@np", bunifuMaterialTextbox4.Text);
                cmd.Parameters.AddWithValue("@p", bunifuMaterialTextbox2.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();
                Form15 f = new Form15();
                f.Show();
                this.Close();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form15 f = new Form15();
            f.Show();
            this.Close();
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
                SqlCommand cmd = new SqlCommand("delete from utilisateurs where utilisateur=@c", cnx);
                cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();
                this.Close();
                Form15 f = new Form15();
                f.Show();


            }
        }
    }
}
