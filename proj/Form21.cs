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
    public partial class Form21 : Form
    {
        public Form21()
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
        private void Form21_Load(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("insert into Resu values (@Nom,@Idreçu,@dabonnmente,@typeabo,@montant,@mode )", cnx);
                cmd.Parameters.AddWithValue("@Nom", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Idreçu", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@dabonnmente", Convert.ToDateTime(bunifuDatepicker1.Value));
                cmd.Parameters.AddWithValue("@typeabo", comboBox2.Text);
                cmd.Parameters.AddWithValue("@montant", bunifuMaterialTextbox3.Text);
                cmd.Parameters.AddWithValue("@mode", comboBox1.Text);
                cmd.ExecuteNonQuery();
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
