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

                    cmd.Parameters.Add("@cat", SqlDbType.NVarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = textBox4.Text;

                    // Let's ask the db to execute the query
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Row inserted!!" );
                    else
                        // Well this should never really happen
                        MessageBox.Show("No row inserted");

                }
            }
            catch (Exception ex)
            {
                // We should log the error somewhere, 
                // for this example let's just show a message
                MessageBox.Show("ERROR:" + ex.Message);
            }


        }
    }
}
