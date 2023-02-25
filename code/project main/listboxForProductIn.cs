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
    public partial class listboxForProductIn : Form
    {
        ProductIn select1;

        SqlConnection con = new SqlConnection(
          @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");

        SqlCommand cmd;
        SqlDataReader dr;
        public listboxForProductIn()
        {
            InitializeComponent();
            InitializeComponent();
            button2.BackColor = System.Drawing.Color.Transparent;
            button2.Parent = pictureBox1;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String value1 = listBox1.SelectedItem.ToString();
            // listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            ProductIn f2 = new ProductIn(value1);

            f2.Show();
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void listboxForProductIn_Load(object sender, EventArgs e)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductIn listboxForProductIn = new ProductIn();
            listboxForProductIn.ShowDialog();
        }
    }
}
