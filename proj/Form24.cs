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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox4.Text == "" || bunifuMaterialTextbox2.Text == "")

            {
                MessageBox.Show("remplirer les champes", "problème de remplissage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into utilisateurs values (@i,@c,@n,@g)", cnx);
                cmd.Parameters.AddWithValue("@i", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox4.Text);
                cmd.Parameters.AddWithValue("@n", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@g", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();
                Form15 f = new Form15();
                f.Show();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
            Form15 f = new Form15();
            f.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form24_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
