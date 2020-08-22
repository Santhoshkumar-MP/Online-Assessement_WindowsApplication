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
    public partial class Form7 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = DESKTOP-FFEE3LJ\SQLEXPRESS; Database = onlineassessment; Integrated Security =true");
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Staff");
            comboBox1.Items.Add("Candidate");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Staff")
            {
                groupBox1.Visible = true;
                dataGridView1.ClearSelection();
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from staff ", db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                db.Close();
            }
            else if (comboBox1.Text == "Candidate")
            {
                groupBox2.Visible = true;
                dataGridView2.ClearSelection();
                db.Open();
                SqlCommand cmd = new SqlCommand("select * from candidate ", db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                db.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand cmd = new SqlCommand("update staff  set Category=' " + textBox2.Text + " ', Status ='approved'  where Name='" + textBox1.Text + "' ", db);
            cmd.ExecuteNonQuery();
            db.Close();
            MessageBox.Show("Updated successfully");
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand cmd = new SqlCommand("update candidate  set Category=' " + textBox2.Text + " ', Status ='approved' where Name='" + textBox4.Text + "' ", db);
            cmd.ExecuteNonQuery();
            db.Close();
            MessageBox.Show("Updated successfully");
            groupBox2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 page2 = new Form2();
            page2.Show();
            this.Close();
        }
    }
}
