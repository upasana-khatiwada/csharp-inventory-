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
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void products_Load(object sender, EventArgs e)
        {

           // con.Open();
           /////* -------------------------------to sh*/ow data on the gridview by concatenating------------ -
           // string query = "Insert into productlist" + "( name,address,age,contact)" +
           //     "values('" +
           //     textBox1.Text +
           //     "','" + textBox2.Text +
           //     "','" + textBox3.Text +
                
           //     "')";


           // SqlCommand cmd = con.CreateCommand();
           // cmd.CommandText = query;
           // cmd.ExecuteNonQuery();
           // con.Close();
           con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(SN)");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();  
            AddProduct AddProductForm = new AddProduct();
            AddProductForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select * from productlist";
            SqlCommand SqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int sn = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Item_Name = dt.Rows[i]["item_name"].ToString();
                string Rate = dt.Rows[i]["category"].ToString();
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
    }
}
