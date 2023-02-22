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
    public partial class selectProduct_listBox_ : Form
    {
        ProductOut select;

        SqlConnection con = new SqlConnection(
          @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");

        SqlCommand cmd;
        SqlDataReader dr;
        public selectProduct_listBox_()
        {
            InitializeComponent();
        }

        private void selectProduct_listBox__Load(object sender, EventArgs e)
        {
            try
            {

                //con.Open();
                //using (SqlConnection command = new SqlConnection())
                //{
                //    command.con = con;
                //    command.CommandText = "SELECT CountryName FROM Countries ";
                //    //whenever you want to get some data from the database
                //    using (SqlDataReader reader = command.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            listBox1.Items.Add(reader["CountryName"].ToString());
                //        }
                //    }
                //}

                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM productlist";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listBox1.Items.Add(dr["item_name"]);
                }
                con.Close();

               // listBox1.SelectionMode = SelectionMode.MultiSimple;
            }
            catch (Exception l)
            {
                MessageBox.Show("Error:" + l);
            }
            //finally
            //{
            //    con.Close();
            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            String value = listBox1.SelectedItem.ToString();
            // listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            ProductOut f2 = new ProductOut(value);

            f2.Show();
            MessageBox.Show(listBox1.SelectedItem.ToString());



        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
