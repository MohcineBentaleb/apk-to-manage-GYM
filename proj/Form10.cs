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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public void repCombo()
        {
            cnx.Open();
            cmd = new SqlCommand("SELECT * FROM Clients", cnx);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "IdClient";
           comboBox3.ValueMember = "IdClient";
            dr.Close();
            cnx.Close();
            

        }
        private void Form10_Load(object sender, EventArgs e)
        {
            repCombo();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox5.Text == "" || bunifuMaterialTextbox6.Text == "" || bunifuMaterialTextbox7.Text == "" || comboBox1.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("remplirer les champes");
            }
            else
            {
                cnx.Open();
            SqlCommand cmd = new SqlCommand("update Contrat set Nom=@d,Tarifaire=@t,DateContrat=@dc,DateFin=@df,ControleAcces=@ca,MontantTotal=@m,Reste =@r,Avance=@a  where IdContrat=@c ", cnx);
            cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
            cmd.Parameters.AddWithValue("@d", comboBox3.Text);
            cmd.Parameters.AddWithValue("@t", comboBox1.Text);
            cmd.Parameters.AddWithValue("dc", Convert.ToDateTime(bunifuDatepicker1.Value));
            cmd.Parameters.AddWithValue("df", Convert.ToDateTime(bunifuDatepicker2.Value));
            cmd.Parameters.AddWithValue("@ca", comboBox4.Text);
            cmd.Parameters.AddWithValue("@m", bunifuMaterialTextbox7.Text);
            cmd.Parameters.AddWithValue("@r", bunifuMaterialTextbox6.Text);
            cmd.Parameters.AddWithValue("@a", bunifuMaterialTextbox5.Text);
            cmd.ExecuteNonQuery();
            cnx.Close();
            this.Close();
            Form8 f = new Form8();
            f.Show();
            }

        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Close();
            
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker2_onValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("delete from Contrat where IdContrat=@c", cnx);
                cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();
                this.Close();
                Form8 f = new Form8();
                f.Show();


            }
        }
    }
}
