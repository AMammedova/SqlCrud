using SqlCrudOperation.Models;
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

namespace SqlCrudOperation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                     
                    cmd.Connection = con;
                    cmd.CommandText = "select * from Users";
                    using(SqlDataReader sqldatareader = cmd.ExecuteReader())
                    {
                        while (sqldatareader.Read())
                        {
                            
                            textBox5.Text = sqldatareader.GetValue(0).ToString();
                            textBox1.Text = sqldatareader.GetValue(1).ToString();
                            textBox2.Text = sqldatareader.GetValue(2).ToString();
                            textBox3.Text = sqldatareader.GetValue(3).ToString();
                            textBox4.Text =sqldatareader.GetValue(4).ToString();

                            
                          
                        }
                    }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True"))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert INTO Users ([Id],[Name],[Surname],[Email],[Age]) Values(@id,@name,@surname,@email,@age)";
                    cmd.Parameters.AddWithValue("@id", textBox5.Text);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@surname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@age", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("done");
                    
                }
                   
               

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True"))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Update Users set Name=@name,Surname=@surname,Email=@email,Age=@age where Id=@id";
                    
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@surname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@age", textBox4.Text);
                    cmd.Parameters.AddWithValue("@id", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("awesome");

                }



            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True"))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from Users where Id=@id";

          
                    cmd.Parameters.AddWithValue("@id", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("great job");

                }



            }
        }
    }
    
}
