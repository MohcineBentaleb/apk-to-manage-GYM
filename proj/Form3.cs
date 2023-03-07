using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {

            var cs = ConfigurationManager.AppSettings;
            
            if (cs["jj"] == "admin")
            {
                bunifuImageButton3.Enabled = true;
                bunifuImageButton4.Enabled = true;
                bunifuImageButton5.Enabled = true;
                bunifuImageButton2.Enabled = true;
                pictureBox2.Visible = true;
                pictureBox2.Visible = true;
                label6.Visible = true;

            }
            else
            {
                bunifuImageButton3.Enabled = true;
                bunifuImageButton4.Enabled = true;
                bunifuImageButton5.Enabled = true;
                bunifuImageButton2.Enabled = true;
               pictureBox2.Visible = false;
                label6.Visible = false;
                panel5.Location = new Point(120, 208);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            this.Hide();
            f.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            this.Hide();
            f.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            this.Hide();
            f.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            this.Hide();
            f.Show();
        }

       

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16();
            this.Hide();
            f.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16();
            this.Hide();
            f.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            this.Hide();
            f.Show();
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form15 f = new Form15();
            this.Hide();
            f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
