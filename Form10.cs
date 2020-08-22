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
    public partial class Form10 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = DESKTOP-FFEE3LJ\SQLEXPRESS; Database = onlineassessment; Integrated Security =true");
        public Form10(string perform_type)
        {
            InitializeComponent();
            label1.Text = perform_type;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 page2 = new Form2();
            page2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Candidate")
            {
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from Rank where Name=' " +comboBox1.Text+ " ' ",db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                db.Close();
            }
            else if(label1.Text == "Category")
            {
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from Rank  ", db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                db.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if(label1.Text == "Category")
            {
                comboBox1.Items.Clear();
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from category", db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "category_name";
                db.Close();
            }
            else if (label1.Text == "Candidate")
            {
                comboBox1.Items.Clear();
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from candidate", db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                db.Close();
            }
        }
    }
}
