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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
     
       
        SqlDataReader drr;
        DataTable dtt = new DataTable();
        public static SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        public static SqlDataAdapter dap;
        public static SqlCommand cmd = new SqlCommand();
        public static CrystalReport1 cr1 = new CrystalReport1();
        public static DataSet1 ds = new DataSet1();
        public void remplisageDGV()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From Contrat";
            drr = cmd.ExecuteReader();
            dtt.Load(drr);
            bunifuCustomDataGrid1.DataSource = dtt;
            
            cnx.Close();
        }
        public void restart()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From Contrat";
            SqlDataAdapter WAC = new SqlDataAdapter(cmd);
            SqlCommandBuilder bb = new SqlCommandBuilder();
            var ds = new DataSet();
            WAC.Fill(ds);
            bunifuCustomDataGrid1.DataSource = ds.Tables[0];
            cnx.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            remplisageDGV();
            restart();
        }

        private void Créer_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            this.Hide();
            f.Show();
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
           
            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            ff.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select *from Contrat where IdContrat='" + bunifuMaterialTextbox1.Text + "'", cnx);
            dap = new SqlDataAdapter(cmd);
            cmd.Connection = cnx;
            dap.Fill(ds, "Contrat");
            cr1.SetDataSource(ds);
            Form13 fr = new Form13();
            fr.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string h = string.Empty;
            Form3 f = new Form3();
            this.Hide();
            f.Show();
            this.Close();

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            cnx.Open();
            if (dtt.Rows != null)
            {
                dtt.Clear();
            }
            SqlCommand cmd = new SqlCommand("select * from Contrat where IdContrat=@c", cnx);
            cmd.Parameters.AddWithValue("@c", bunifuMaterialTextbox1.Text);
            drr = cmd.ExecuteReader();
            dtt.Load(drr);
            bunifuCustomDataGrid1.DataSource = dtt;
            cnx.Close();

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Form10 ff = new Form10();
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.bunifuCustomDataGrid1.Rows[e.RowIndex];
                ff.bunifuMaterialTextbox1.Text = row.Cells[0].Value.ToString();
                ff.comboBox3.Text = row.Cells[1].Value.ToString();
                ff.comboBox1.Text = row.Cells[2].Value.ToString();
                ff.bunifuDatepicker1.Text = row.Cells[3].Value.ToString();
                ff.bunifuDatepicker2.Text = row.Cells[4].Value.ToString();
                ff.comboBox4.Text = row.Cells[5].Value.ToString();
                ff.bunifuMaterialTextbox7.Text = row.Cells[6].Value.ToString();
                ff.bunifuMaterialTextbox6.Text = row.Cells[7].Value.ToString();
                ff.bunifuMaterialTextbox5.Text = row.Cells[8].Value.ToString();
            }
        }
    }
}
