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
    public partial class Form9 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = DESKTOP-FFEE3LJ\SQLEXPRESS; Database = onlineassessment; Integrated Security =true");
        public Form9(string name)
        {
            InitializeComponent();
            label2.Text = name;
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            db.Open();
            SqlCommand cmd = new SqlCommand("select *from category", db);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "category_name";
            db.Close();
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
        int i = 1;
        int score = 0;
        string answer;
        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
                Question();
        }

        public void Question()
        {
            db.Open();
            SqlCommand cmd = new SqlCommand("select * from  "+ comboBox1.Text+"  where  Q_no = " + i.ToString()+ " ", db);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label6.Text = dr.GetValue(0).ToString();
                richTextBox1.Text = dr.GetString(1);
                radioButton1.Text = dr.GetString(2);
                radioButton2.Text = dr.GetString(3);
                radioButton3.Text = dr.GetString(4);
                answer = dr.GetString(5);
            }
            db.Close();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                    if (radioButton1.Text == answer)
                    {
                        score = score+ 1;
                    }
            }
            else  if (radioButton2.Checked == true)
            {
                    if (radioButton2.Text == answer)
                    {
                        score = score+ 1;
                    }
            }
           else  if (radioButton3.Checked == true)
            {
                    if (radioButton3.Text == answer)
                    {
                        score = score+1;
                    } 
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            i++;
            Question();
        }
        int rank_name=0,rank_scores=0;
        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            db.Open();
            SqlCommand cmd = new SqlCommand("select * from Rank where Name =' " + label2.Text + " ' ", db);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == false)
            {
                rank_name = 1;
            }
            else if(dr.HasRows==true)
            {
                rank_scores = 1;
             }
            db.Close();
            if(rank_name==1)
            {
                db.Open();
                SqlCommand cmd1 = new SqlCommand("insert into Rank (Name,"+ comboBox1.Text+") values (' "+ label2.Text+ "' ,' "+score.ToString()+" ') ", db);
                cmd1.ExecuteNonQuery();
                db.Close();
                rank_name = 0;
            }
            else if(rank_scores==1)
            { 
                db.Open();
                SqlCommand cmd2 = new SqlCommand("update Rank set " + comboBox1.Text + " =" + score.ToString() + "   where  Name=' " + label2.Text + " ' ", db);
                cmd2.ExecuteNonQuery();
                db.Close();
                rank_scores = 0;
            }
            MessageBox.Show(score.ToString());
            score = 0;

        }
    }
}
