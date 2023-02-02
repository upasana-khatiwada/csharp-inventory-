using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_main
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            button3.BackColor = System.Drawing.Color.Transparent;
            button3.Parent = pictureBox1;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form3 DashBoard = new Form3();
            DashBoard.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductOut DashBoard = new ProductOut();
            DashBoard.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductIn DashBoard = new ProductIn();
            DashBoard.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
