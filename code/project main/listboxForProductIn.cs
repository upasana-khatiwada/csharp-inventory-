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
    }
}
