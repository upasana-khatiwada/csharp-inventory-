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
    public partial class ProductOut : Form
    {
        SqlConnection con = new SqlConnection(
          @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");

        public bool Quantity { get; }

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

                if (value== Item_Name)
                {
                    string Quantity = dt.Rows[i]["Quantity"].ToString();

                    totalQty = totalQty + Convert.ToDecimal(Quantity);
                }

                



                

            }
            
            textBox2.Text = Convert.ToString(totalQty);
            con.Close();




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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();

            Decimal addedQty = 0;



            string item_selected = textBox1.Text;
            string query = "Select count(*) From productlist WHERE item_name='" + item_selected + "'";


            addedQty =   Convert.ToDecimal(textBox2.Text)- Convert.ToDecimal(textBox3.Text);



            string query1 = "UPDATE productlist SET quantity=@qty where item_name  = @item ";
            SqlCommand SqlCommand = new SqlCommand(query1, con);

            SqlCommand.Parameters.AddWithValue("@item", item_selected);



            SqlCommand.Parameters.AddWithValue("@qty", addedQty);
            SqlCommand.ExecuteNonQuery();
            MessageBox.Show("Product Added!!");


            //this.Hide(); //hides the first form 
            //DashBoard LoginForm = new DashBoard();
            //LoginForm.ShowDialog();

            //this.Hide(); //hides the first form 
            //productInBill LoginForm = new productInBill();
            //LoginForm.ShowDialog();

            con.Close();
        }
    }
}
