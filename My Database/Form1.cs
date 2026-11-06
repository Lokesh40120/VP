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
using MySql.Data.MySqlClient;

namespace My_Database
{
    public partial class Form1 : Form
    {
        // Connection string for MySQL. Add user id if required by your server.
        private string connectionString = "server=localhost;user id=root;password=monkey;database=sec51_db;port=3306;";
        MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MessageBox.Show(conn.State.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null || conn.State != System.Data.ConnectionState.Open)
                {
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                }

                string query;
                MySqlDataAdapter da;

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    query = "SELECT * FROM Student";
                    da = new MySqlDataAdapter(query, conn);
                }
                else
                {
                    query = "SELECT * FROM Student WHERE Department = @dept";
                    da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@dept", textBox1.Text);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("Total Student Records:" + dt.Rows.Count);
            }
            catch (Exception err){
                MessageBox.Show(err.Message);
            }
        }


        // Designer event handler stubs (no-op) referenced from the designer
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadStudentID();
        }

        private void button5_Click(object sender, EventArgs e)
        { 
            insertRecord();
        }
        public void insertRecord() 
        { 
            try
            {
                string query = @"INSERT INTO Student (StudentID, StudentName, Department, year) VALUES (@id, @name, @dept, @year)";
                if (conn == null || conn.State != System.Data.ConnectionState.Open)
                {
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                }
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.Parameters.AddWithValue("@dept", textBox4.Text);
                cmd.Parameters.AddWithValue("@year", textBox5.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student inserted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
             
        }
        public void loadStudentID()
        {
            comboBox1.Items.Clear();
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Student";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int added = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (added >= 16)
                        break;
                    if (row == null)
                        continue;
                    if (!dt.Columns.Contains("StudentId"))
                        break; // no such column, stop trying
                    var val = row["StudentId"];
                    if (val == null || val == DBNull.Value)
                        continue;
                    comboBox1.Items.Add(val.ToString());
                    added++;
                }

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadStudentID();
        }
    }
}