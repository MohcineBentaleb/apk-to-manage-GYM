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
    
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
       /// SqlDataReader dr;
       // DataTable dt = new DataTable();

        private void Form5_Load(object sender, EventArgs e)
        {
            
            
        }
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox2.Text == "" || bunifuMaterialTextbox3.Text == "" || bunifuMaterialTextbox4.Text == "")

            {
                MessageBox.Show("remplirer les champes", "problème de remplissage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into Clients values (@i,@c,@n,@p,@d,@s )", cnx);
                cmd.Parameters.AddWithValue("@i", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@n", bunifuMaterialTextbox3.Text);
                cmd.Parameters.AddWithValue("@p", bunifuMaterialTextbox4.Text);
                cmd.Parameters.AddWithValue("@d", Convert.ToDateTime(bunifuDatepicker1.Value));
                cmd.Parameters.AddWithValue("@s", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();
                Form4 f = new Form4();
                f.Show();
            }







        }


            private void bunifuThinButton22_Click(object sender, EventArgs e)
            {
            this.Close();
            Form4 f = new Form4();
            f.Show();
            }

            private void bunifuImageButton1_Click(object sender, EventArgs e)
            {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
