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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 f = new Form4();
            f.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox2.Text == "" || bunifuMaterialTextbox3.Text == "" || bunifuMaterialTextbox4.Text == "")

            {
                MessageBox.Show("remplirer les champes", "problème de remplissage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnx.Open();
                 SqlCommand cmd = new SqlCommand("update Clients set Nom=@n,Prenom=@p,Cin=@t,DateNaissance=@m,sex=@v where IdClient=@c ", cnx);
                 cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
                 cmd.Parameters.AddWithValue("@n", bunifuMaterialTextbox2.Text);
                 cmd.Parameters.AddWithValue("@p", bunifuMaterialTextbox3.Text);
                 cmd.Parameters.AddWithValue("@m", Convert.ToDateTime(bunifuDatepicker1.Value));
                 cmd.Parameters.AddWithValue("@t", bunifuMaterialTextbox4.Text);
                 cmd.Parameters.AddWithValue("@v", comboBox1.Text);
                 cmd.ExecuteNonQuery();
                 cnx.Close();
                this.Close();
                Form5 f = new Form5();
                f.Show();
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            {
                if (bunifuMaterialTextbox1.Text == "")

                {
                    MessageBox.Show("remplirer les champes", "problème de remplissage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("delete from Clients where IdClient=@c", cnx);
                    cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    this.Close();
                    Form5 f = new Form5();
                    f.Show();
                }
            }
        }
    }
}
