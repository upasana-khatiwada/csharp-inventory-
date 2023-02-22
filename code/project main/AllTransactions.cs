using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_main
{
    public partial class AllTransactions : Form
    {
        SqlConnection con = new SqlConnection(
           @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");
        public AllTransactions()
        {
            InitializeComponent();

            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Parent = pictureBox1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 AllTransactions = new Form3();
            AllTransactions.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AllTransactions_Load(object sender, EventArgs e)
        {
            ///for the stock available -------------------------------------------------
            string query1 = "select quantity,category from productlist";
            SqlCommand SqlCommand = new SqlCommand(query1, con);
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            Decimal Product_InHand = 0;
            Decimal Product_Out = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                string Quantity = dt.Rows[i]["Quantity"].ToString();
                Product_InHand = Product_InHand +Convert.ToDecimal(Quantity);


                

            }
            //textbox1 left(total product in)
            textBox2.Text = Convert.ToString(Product_Out);
            textBox3.Text = Convert.ToString(Product_InHand);
        }

    }
}
