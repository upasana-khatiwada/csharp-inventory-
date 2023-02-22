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
    public partial class ProductIn : Form
    {
        SqlConnection con = new SqlConnection(
         @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");

        public ProductIn()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Parent = pictureBox1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;



        }
        public ProductIn(string value1)
        {
            InitializeComponent();
            textBox1.Text = value1;

            ///

            con.Open();

            ///
            string query = "select * from productlist";

            SqlCommand SqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            decimal RowNum = dt.Rows.Count;




            //to fetch the total available stock of the selected item---------------------------------------------------------
            string query1 = "select item_name quantity from productlist";
            Decimal totalQty = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Item_Name = dt.Rows[i]["item_name"].ToString();

                if (value1 == Item_Name)
                {
                    string Quantity = dt.Rows[i]["Quantity"].ToString();

                    totalQty = totalQty + Convert.ToDecimal(Quantity);
                }







            }

            textBox2.Text = Convert.ToString(totalQty);
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard ProductIn = new DashBoard();
            ProductIn.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            listboxForProductIn showlist1 = new listboxForProductIn();
            showlist1.ShowDialog();

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();

            Decimal addedQty = 0;



            string item_selected = textBox1.Text;
            string query = "Select count(*) From productlist WHERE item_name='" + item_selected + "'";

            
            addedQty = Convert.ToDecimal(textBox3.Text) + Convert.ToDecimal(textBox2.Text);
            


            string query1 = "UPDATE productlist SET quantity=@qty where item_name  = @item ";
            SqlCommand SqlCommand = new SqlCommand(query1, con);

            SqlCommand.Parameters.AddWithValue("@item", item_selected);

           

            SqlCommand.Parameters.AddWithValue("@qty", addedQty);
            SqlCommand.ExecuteNonQuery();
            MessageBox.Show("Product Added!!");


            //this.Hide(); //hides the first form 
            //DashBoard LoginForm = new DashBoard();
            //LoginForm.ShowDialog();

            this.Hide(); //hides the first form 
            productInBill LoginForm = new productInBill();
            LoginForm.ShowDialog();

            con.Close();
        }
    }
}
