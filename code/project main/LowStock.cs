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
    public partial class LowStock : Form
    {
        SqlConnection con = new SqlConnection(
          @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");
        public LowStock()
        {
            InitializeComponent();


            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Parent = pictureBox1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;



            //DataTable productlist = new DataTable();



            //con.Open();

            //string query = "Select item_name from productlist where quantity < 5 ";
            //SqlCommand cmd = new SqlCommand(query, con);


            //Clear the datatable to prevent duplicate generation of data in gridview.
            //productlist.Clear();
            //SqlDataAdapter adapter = new SqlDataAdapter("Select * from productlist where quantity < 5", con);


            //adapter.Fill(productlist);

            //SqlDataReader reader;
            //reader = cmd.ExecuteReader();

            //StringBuilder productNames = new StringBuilder();

            //while (reader.Read())
            //{
            //    productNames.Append(reader["item_name"].ToString() + Environment.NewLine);
            //}

            //con.Close();

            //MessageBox.Show("There are products that needs restocking, check to restock now." + productNames);

            // Display items in the ListView control
            //for (int i = 0; i < productlist.Rows.Count; i++)
            //{

            //    DataRow drow = productlist.Rows[i];

            //    // Only row that have not been deleted
            //    if (drow.RowState != DataRowState.Deleted)
            //    {
            //        // Define the list items
            //        //ListViewItem lvi = new ListViewItem(drow["bnum"].ToString());
            //        ListViewItem lvi = new ListViewItem(drow["item_id"].ToString());
            //        lvi.SubItems.Add(drow["item_name"].ToString());
            //        //lvi.SubItems.Add(drow["descr"].ToString());
            //        //lvi.SubItems.Add(((DateTime)drow["dater"]).ToShortDateString());
            //        //lvi.SubItems.Add(drow["exp"].ToString());
            //        //lvi.SubItems.Add(((DateTime)drow["exp"]).ToShortDateString());
            //        lvi.SubItems.Add(drow["category"].ToString());
            //        lvi.SubItems.Add(drow["quantity"].ToString());


            //        // Add the list items to the ListView
            //        listView.Items.Add(lvi);

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LowStock_Load(object sender, EventArgs e)
        {
            string query = "Select item_name, category,quantity from productlist where quantity < 5 ";
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
                dataGridView1.Rows.Add(sn++, Item_Name, Rate, Quantity, Total_p);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 LowStock = new Form3();
            LowStock.ShowDialog();
        }
    }
        }




        //string query = "Select item_name from productlist where quantity < 5 ";
        // SqlCommand cmd = new SqlCommand(query,con);
        ////SqlCommand cmd = new SqlCommand("Select pname from inventory where qt < 5", con);
        //con.Open();
        //SqlDataReader reader = cmd.ExecuteReader();
        //StringBuilder productNames = new StringBuilder();
        //while (reader.Read())
        //{
        //    productNames.Append(reader["pname"].ToString() + Environment.NewLine);
        //}
        //con.Close();
//        //MessageBox.Show("Following Products quantity is lessthan 5\n" + productNames);
//    }
//    }
//}
