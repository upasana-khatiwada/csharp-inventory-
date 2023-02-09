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
    public partial class AllTransactions : Form
    {
        public AllTransactions()
        {
            InitializeComponent();

            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Parent = pictureBox1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 AllTransactions = new Form3();
            AllTransactions.ShowDialog();
        }
    }
}
