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
    public partial class ProductOut : Form
    {
        public ProductOut()
        {
            InitializeComponent();
            button4.BackColor = System.Drawing.Color.Transparent;
            button4.Parent = pictureBox1;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;


            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;
        }
        
        public ProductOut( string value)
        {
            InitializeComponent();
            textBox1.Text = value;


            button4.BackColor = System.Drawing.Color.Transparent;
            button4.Parent = pictureBox1;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void ProductOut_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            selectProduct_listBox_ showlist = new selectProduct_listBox_();
            showlist.ShowDialog();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard ProductOut = new DashBoard();
            ProductOut.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
