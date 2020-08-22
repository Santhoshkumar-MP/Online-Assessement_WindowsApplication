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
    public partial class Form3 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = DESKTOP-FFEE3LJ\SQLEXPRESS; Database = onlineassessment; Integrated Security =true");
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Approved");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Adding:
            db.Open();
            SqlCommand cmd = new SqlCommand("insert into staff  values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString()+ "' )", db);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Regsistration Completed successfully");
            db.Close();
            //Going back:
            Form2 page2 = new Form2();
            page2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 page2 = new Form2();
            page2.Show();
            this.Close();
        }
    }
}
