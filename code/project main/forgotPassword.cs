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
    public partial class forgotPassword : Form
    {

        SqlConnection con = new SqlConnection(
          @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");
        public forgotPassword()
        {
            InitializeComponent();

            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;


            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            button2.BackColor = System.Drawing.Color.Transparent;
            button2.Parent = pictureBox1;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string getContact = textBox1.Text;
            string query = "Select count(*) From employees1 WHERE phone_number='" + getContact + "'";
            SqlCommand cmd1 = new SqlCommand(query, con);
            int count=Convert.ToInt32(cmd1.ExecuteScalar());
            if (count > 0)
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE employees1  SET password = @pass where phone_number  = @phn ", con))
                {
                    cmd.Parameters.AddWithValue("@phn", textBox1.Text);
                    if (textBox2.Text.Equals(textBox3.Text))
                    {
                        cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Password Has Been Updated");
                        this.Hide(); //hides the first form 
                        Form1 LoginForm = new Form1();
                        LoginForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }




                }
            }
            else
            {
                MessageBox.Show("Invalid phone number");
            }
            ////if(dr.Read())
            ////{
            ////    textBox1.Text = dr.GetValue(1).ToString();

            ////}
            ////else
            ////{
            ////    MessageBox.Show("do not matched");
            ////}
            //SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    //string data1 = dt.Rows[0]["Email"].ToString();
            //    // string data2 = dt.Rows[0]["contact"].ToString();
            //    string data2 = dt.Rows[0]["phone_number"].ToString();
            //    textBox1.Text = data2;
            //    MessageBox.Show("Your Password Has Been Updated");
            //}
            con.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forgotPassword = new Form1();
            forgotPassword.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
