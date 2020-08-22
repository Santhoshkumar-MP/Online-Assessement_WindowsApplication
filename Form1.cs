using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Online_Assessment
{
    public partial class Form1 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = DESKTOP-FFEE3LJ\SQLEXPRESS; Database = onlineassessment; Integrated Security =true");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("staff");
            comboBox1.Items.Add("candidate");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "Admin@123")
            {
                MessageBox.Show("Welcome Admin");
                Form2 Page2 = new Form2();
                 Page2.Show();
                 this.Hide(); 
            }
            else if (comboBox1.Text == "staff")
            {
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from staff  where Name = '" + textBox1.Text + "' and Password ='" + textBox2.Text + "' ", db);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    if (dr.GetValue(4).ToString() == "approved" || dr.GetValue(4).ToString() == "Approved")
                    {
                        MessageBox.Show("Welcome  " + textBox1.Text);
                        Form8 Page8 = new Form8(textBox1.Text);
                        Page8.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You are not yet Approved");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User");
                }
                db.Close();
            }
            else if (comboBox1.Text == "candidate")
            {
                db.Open();
                SqlCommand cmd1 = new SqlCommand("select * from candidate  where Name = '" + textBox1.Text + "' and Password ='" + textBox2.Text + "' ", db);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read() == true)
                {
                    if (dr1.GetValue(4).ToString() == "approved" || dr1.GetValue(4).ToString() == "Approved")
                    {
                        MessageBox.Show("Welcome  " + textBox1.Text);
                        Form9 Page9 = new Form9(textBox1.Text);
                        Page9.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You are not yet Approved");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User");
                }
                db.Close();
            }
            panel2.Visible = false;
            panel4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "staff")
            {
                if (textBox5.Text == textBox6.Text && textBox5.Text != " ")
                {
                    db.Open();
                    SqlCommand cmd = new SqlCommand("insert into staff  values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + "pending" + "','" + "pending" + "' )", db);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Regsistration Completed successfully");
                    db.Close();
                }
                else
                {
                    MessageBox.Show("Password didn't match confirm paasword please Re-enter password");
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "candidate")
            {
                if (textBox5.Text == textBox6.Text)
                {
                    db.Open();
                    SqlCommand cmd = new SqlCommand("insert into candidate  values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "' ,'" + "pending" + "','" + "pending"+"' ,'"+"0"+"' )", db);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Regsistration Completed successfully");
                    db.Close();
                }
                else
                {
                    MessageBox.Show("Password didn't match confirm paasword please Re-enter password");
                }
            }
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = false;
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = false;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {}
    }
}
