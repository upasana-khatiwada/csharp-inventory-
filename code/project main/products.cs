﻿using System;
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
    public partial class products : Form
    {

        SqlConnection con = new SqlConnection(
           @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");
        public products()
        {
            InitializeComponent();
            button4.BackColor = System.Drawing.Color.Transparent;
            button4.Parent = pictureBox1;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            button2.BackColor = System.Drawing.Color.Transparent;
            button2.Parent = pictureBox1;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Parent = pictureBox1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void products_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();

            con.Open();
            ///* -------------------------------to show total number of item (available quantity of item)------------ -
            ///
            string query = "select * from productlist";
            
            SqlCommand SqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            decimal RowNum = dt.Rows.Count;

            textBox1.Text =Convert.ToString( RowNum);


            //to addd total quantity---------------------------------------------------------
            string query1 = "select quantity,category from productlist";
            Decimal totalQty = 0;
            Decimal totalStockPrice = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Rate = dt.Rows[i]["category"].ToString();
                string Quantity = dt.Rows[i]["Quantity"].ToString();
                 totalQty = totalQty +Convert.ToDecimal(Quantity) ;

                Decimal Total_p = Convert.ToDecimal(Rate) * Convert.ToDecimal(Quantity);
               totalStockPrice = totalStockPrice+Convert.ToDecimal(Total_p);
                //string Total_Price = dt.Rows[i]["Total_price"].ToString();
                //dataGridView1.Rows.Add(sn++, Item_Name, Rate, Quantity, Total_p);

            }
            textBox2.Text = Convert.ToString(totalQty);
            textBox3.Text = Convert.ToString(totalStockPrice);




            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query1;
            cmd.ExecuteNonQuery();
            con.Close();


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();  
            AddProduct AddProductForm = new AddProduct();
            AddProductForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            string query = "select * from productlist";
            SqlCommand SqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int sn = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Item_Name = dt.Rows[i]["item_name"].ToString();
                string Rate = dt.Rows[i]["Category"].ToString();
                string Quantity = dt.Rows[i]["Quantity"].ToString();
                Decimal Total_p = Convert.ToDecimal(Rate) * Convert.ToDecimal(Quantity);
                //string Total_Price = dt.Rows[i]["Total_price"].ToString();
                dataGridView1.Rows.Add(sn++, Item_Name, Rate, Quantity,Total_p);

            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                this.dataGridView1.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 products = new Form3();
            products.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
