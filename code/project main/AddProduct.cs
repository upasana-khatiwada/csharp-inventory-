using System;
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
    public partial class AddProduct : Form
    {

        SqlConnection con = new SqlConnection(
          @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");
        public AddProduct()
        {
            InitializeComponent();
            //label1.Parent = pictureBox1;
            //label1.BackColor = Color.Transparent; 
            //label2.Parent = pictureBox1;
            //label2.BackColor = Color.Transparent;
            //label3.Parent = pictureBox1;
            //label3.BackColor = Color.Transparent; 
            //label4.Parent = pictureBox1;
            //label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            button2.BackColor = System.Drawing.Color.Transparent;
            button2.Parent = pictureBox1;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter();

            string query = "INSERT INTO productlist(item_name,item_id,category,quantity) VALUES(@nme,@id,@cat,@qty)";
            

            try
            {
                // Open the connection to the database. 
                // This is the first critical step in the process.
                // If we cannot reach the db then we have connectivity problems
                con.Open();

                // Prepare the command to be executed on the db
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Create and set the parameters values 
                    cmd.Parameters.Add("@nme", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = textBox2.Text;

                    cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@cat", SqlDbType.NVarChar).Value = textBox4.Text;

                    // Let's ask the db to execute the query
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                    {
                        MessageBox.Show("Product Added!!");
                        this.Hide(); //hides the first form 
                        products LoginForm = new products();
                        LoginForm.ShowDialog();
                    }


                    else
                    {
                        // Well this should never really happen
                        MessageBox.Show("No Product Added");
                    }

                }
            }
            catch (Exception ex)
            {
                // We should log the error somewhere, 
                // for this example let's just show a message
                MessageBox.Show("ERROR:" + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            this.Hide();
            products AddProduct = new products();
            AddProduct. ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
