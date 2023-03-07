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
    public partial class Form9 : Form
    {
        public Form9()
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
           cmd = new SqlCommand("SELECT * FROM Clients",cnx);
           dr = cmd.ExecuteReader();
           dt.Load(dr);
           comboBox3.DataSource = dt;
           comboBox3.DisplayMember = "Nom";
           comboBox3.ValueMember = "IdClient";
           dr.Close();
            cnx.Close();

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            repCombo();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

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
                SqlCommand cmd = new SqlCommand("insert into Contrat values (@IdContrat,@Nom,@Tarifaire,@DateContrat,@DateFin,@ControleAcces,@MontantTotal,@Reste,@Avance)", cnx);
                cmd.Parameters.AddWithValue("@IdContrat ", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@Nom", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Tarifaire", comboBox1.Text);
                cmd.Parameters.AddWithValue("@DateContrat ", Convert.ToDateTime(bunifuDatepicker1.Value));
                cmd.Parameters.AddWithValue("@DateFin ", Convert.ToDateTime(bunifuDatepicker2.Value));
                cmd.Parameters.AddWithValue("@ControleAcces ", comboBox4.Text);
                cmd.Parameters.AddWithValue("@MontantTotal", bunifuMaterialTextbox7.Text);
                cmd.Parameters.AddWithValue("@Reste", bunifuMaterialTextbox6.Text);
                cmd.Parameters.AddWithValue("@Avance ", bunifuMaterialTextbox5.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();
                Form8 f = new Form8();
                f.Show();
                this.Close();
            }
        }


    

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {
            //float v =float.Parse( bunifuMaterialTextbox7.Text);

            //float v1 = float.Parse(bunifuMaterialTextbox6.Text);
            //float result = v - v1;
            //bunifuMaterialTextbox5.Text = result.ToString();
        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {
            float k = 0;
            try
            {
                if (bunifuMaterialTextbox6.Text != "")
                {
                    float v = float.Parse(bunifuMaterialTextbox7.Text);

                    float v1 = float.Parse(bunifuMaterialTextbox6.Text);
                    float result = v - v1;
                    bunifuMaterialTextbox5.Text = result.ToString();
                }
                else {
                    bunifuMaterialTextbox6.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
