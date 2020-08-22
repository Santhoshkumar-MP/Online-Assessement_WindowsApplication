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
    public partial class Form2 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = DESKTOP-FFEE3LJ\SQLEXPRESS; Database = onlineassessment; Integrated Security =true");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Staff:-
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Add Staff");
            comboBox1.Items.Add("View Staff");
            //Question:-
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Add Category");
            comboBox2.Items.Add("Add Question");
            comboBox2.Items.Add("View Question");
            //Approval:-
            comboBox3.Items.Clear();
            comboBox3.Items.Add("Open");
            //Performance:-
            comboBox4.Items.Clear();
            comboBox4.Items.Add("Catagory Based");
            comboBox4.Items.Add("Candidate Based");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 page1 = new Form1();
            page1.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }
        //Adding Category
        private void button5_Click_1(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand cmd = new SqlCommand("insert into category values(' " + textBox1.Text + " ' )", db);
            cmd.ExecuteNonQuery();
            db.Close();
            //creating table:-
            db.Open();
            SqlCommand cmd1 = new SqlCommand("CREATE TABLE [" + textBox1.Text + "] (Q_no NVARCHAR(5), Question NVARCHAR (MAX) NOT NULL, OptionA NVARCHAR(50)  NOT NULL,OptionB NVARCHAR(50)  NOT NULL,OptionC NVARCHAR(50),Answer NVARCHAR(50))", db);
            cmd1.ExecuteNonQuery();
            db.Close();
            //Rank Category column:-   
            db.Open();
            SqlCommand cmd2 = new SqlCommand("alter table Rank add " + textBox1.Text + " nvarchar(50) ", db);
            cmd2.ExecuteNonQuery();
            db.Close();

            MessageBox.Show("Done'!'");
            groupBox1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Add Staff" )
            {
                Form3 page3 = new Form3();
                page3.Show();
                this.Hide();
            }
           else  if (comboBox1.Text == "View Staff")
            {
                Form4 page4 = new Form4();
                page4.Show();
                this.Hide();
            } 
          if(comboBox2.Text== "Add Category")
            {
                groupBox1.Visible = true;
            }
           else if (comboBox2.Text == "Add Question")
            {
                Form5 page5 = new Form5(" ",0);
                page5.Show();
                this.Close();
            }
           else  if (comboBox2.Text == "View Question")
            {
                Form6 page6 = new Form6();
                page6.Show();
                this.Close();
            }
            if (comboBox3.Text == "Open")
            {
                Form7 page7 = new Form7();
                page7.Show();
                this.Close();
            }
            if (comboBox4.Text == "Catagory Based")
            {
                Form10 page10 = new Form10("Category");
                page10.Show();
                this.Hide();
            }
            else if (comboBox4.Text == "Candidate Based")
            {
                Form10 page10 = new Form10("Candidate");
                page10.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            groupBox1.Hide();
        }
    }
}
