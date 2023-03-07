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
using System.Configuration;

namespace proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-E36PIJD;Initial Catalog=stage2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter();


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(loginTXT.Text ==""|| passwordTXT.Text == "")
            {
                MessageBox.Show("Entre ID et password");
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            loginTXT.Text = "";
            passwordTXT.Text = "";
        }

        private void passwordTXT_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            passwordTXT.UseSystemPasswordChar = true;
            if (checkBox1.Checked)
            {
                passwordTXT.UseSystemPasswordChar = false;
                checkBox1.Text = "show password";
            }


        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
           
        }
        
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginTXT.Text != "" || passwordTXT.Text != "")
                {
                    sda = new SqlDataAdapter("select * from utilisateurs where utilisateur=@utilisateur and passwordd=@pass", cnx);
                    sda.SelectCommand.Parameters.AddWithValue("@utilisateur", loginTXT.Text);
                    sda.SelectCommand.Parameters.AddWithValue("@pass", passwordTXT.Text);
                    DataTable table = new DataTable();
                    table.Clear();
                    sda.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        var cs = ConfigurationManager.AppSettings;
                        cs["jj"] = table.Rows[0]["grade"].ToString();

                        Form3 f = new Form3();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Utilistaeur ou Mot de pass incorrect");
                    }

                }
                else if (loginTXT.Text == "" || passwordTXT.Text == "")
                {
                    MessageBox.Show("entre les autres champs", "attention", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Utilistaeur ou Mot de pass incorrect");
                }
            }catch(Exception oo)
            {
                MessageBox.Show("Utilistaeur ou Mot de pass incorrect");
                loginTXT.Text = "";
                passwordTXT.Text = "";
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            loginTXT.Text = "";
            passwordTXT.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passwordTXT.UseSystemPasswordChar = false;
                checkBox1.Text = "show password";
            }
            if (!checkBox1.Checked)
            {
                passwordTXT.UseSystemPasswordChar= true;
                checkBox1.Text = "hide password";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
