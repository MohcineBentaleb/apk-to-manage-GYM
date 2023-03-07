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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
      
        
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public static SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        public static SqlDataAdapter dap;
        public static SqlCommand cmd = new SqlCommand();
        private static CrystalReport2 cr1 = new CrystalReport2();
        public static DataSet1 ds = new DataSet1();

        public static CrystalReport2 Cr1 { get => cr1; set => cr1 = value; }

        public void replisageDGV()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From Resu";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt;
            cnx.Close();
        }

        public void restart()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * From Resu";
            SqlDataAdapter WAC = new SqlDataAdapter(cmd);
            SqlCommandBuilder bb = new SqlCommandBuilder();
            var ds = new DataSet();
            WAC.Fill(ds);
            bunifuCustomDataGrid1.DataSource = ds.Tables[0];
            cnx.Close();
        }

        


        private void Form16_Load(object sender, EventArgs e)
        {
            replisageDGV();
            restart();
           

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            cnx.Open();
            if (dt.Rows != null)
            {
                dt.Clear();
            }
            cmd.CommandText = " select * From Resu where NumAbonnelent ='"+ bunifuMaterialTextbox1.Text+ "'";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            bunifuCustomDataGrid1.DataSource = dt;
            cnx.Close();
        }

        private void Créer_Click(object sender, EventArgs e)
        {

            this.Close();
            Form21 f = new Form21();
            f.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            this.Close();
            Form23 f = new Form23();
            FF.Show();
        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select *from Resu where  NumAbonnelent='" + bunifuMaterialTextbox1.Text + "'", cnx);
            dap = new SqlDataAdapter(cmd);
            cmd.Connection = cnx;
            dap.Fill(ds, "Resu");
            Cr1.SetDataSource(ds);
            Form12 fr = new Form12();
            fr.Show();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string h = string.Empty;
            Form3 f = new Form3();
            f.Show();
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public Form23 FF = new Form23();
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                //gets a collection that contains all the rows
                DataGridViewRow row = this.bunifuCustomDataGrid1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.

                FF.comboBox3.Text = row.Cells[0].Value.ToString(); 
                FF.bunifuMaterialTextbox2.Text = row.Cells[1].Value.ToString();
                FF.bunifuDatepicker1.Text = row.Cells[2].Value.ToString();
                FF.comboBox2.Text = row.Cells[3].Value.ToString();
                FF.bunifuMaterialTextbox3.Text = row.Cells[4].Value.ToString();
                FF.comboBox1.Text = row.Cells[5].Value.ToString();

            }
        }
    }
}
