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
    public partial class Form8 : Form
    { 
        SqlConnection db = new SqlConnection(@"Data Source = DESKTOP-FFEE3LJ\SQLEXPRESS; Database = onlineassessment; Integrated Security =true");
        public Form8(string name)
        {
            db.Open();
            SqlCommand cmd = new SqlCommand("select * from staff  where Name =' " + name+ " '  ", db);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read()==true)
            {
                textBox1.Text = dr.GetValue(3).ToString();
            }
            db.Close();
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from  " + textBox1.Text + "  ", db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                db.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 page5 = new Form5( textBox1.Text,1);
            page5.Show();
            this.Close();
        }
    }
}
