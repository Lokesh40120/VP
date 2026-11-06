using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBSampleCrud
{
    public partial class Form1 : Form
    {
        // MySQL connection and connection string
        private MySqlConnection conn;
        static string connectionString = "server=localhost;database=students;user=root;password=Mari1410$";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Prevent design-time execution which can break the Windows Forms Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            loadStudentID();
            loadDataGrid();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtStudId.Text = "";
            TxtName.Text = "";
            TxtDept.Text = "";
            TxtYear.Text = "";
            TxtCGPA.Text = "";
            TxtEmail.Text = "";

        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application under Construction" + DateTime.Now.ToString());
        }


        public void loadStudentID()
        {
            comboBox1.Items.Clear();
            conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM Student";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //MessageBox.Show(dt.Rows.Count.ToString());

            for (int idx = 0; idx < dt.Rows.Count; idx++)
            {
                comboBox1.Items.Add(dt.Rows[idx]["StudentID"].ToString());
            }
            comboBox1.SelectedIndex = 0;
            conn.Close();
        }


        public void loadDataGrid()
        {
            try
            {
                string query = "SELECT * FROM Student";
                conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                MessageBox.Show("Total Student Records: " + dt.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }


        public void insertRecord()
        {
            try
            {
                string query = "INSERT INTO Student VALUES (@id, @name, @dept, @year,@cgpa,@email)";
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", TxtStudId.Text);
                cmd.Parameters.AddWithValue("@name", TxtName.Text);
                cmd.Parameters.AddWithValue("@dept", TxtDept.Text);
                cmd.Parameters.AddWithValue("@year", TxtYear.Text);
                cmd.Parameters.AddWithValue("@cgpa", TxtCGPA.Text);
                cmd.Parameters.AddWithValue("@email", TxtEmail.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student inserted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public void updateRecord()
        {
            string query = @"UPDATE Student
                     SET StudentName = @name,
                         Department = @dept,
                         year = @year,
                           email=@email
                     WHERE StudentID = @id";

            conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", TxtStudId.Text);
            cmd.Parameters.AddWithValue("@name", TxtName.Text);
            cmd.Parameters.AddWithValue("@dept", TxtDept.Text);
            cmd.Parameters.AddWithValue("@year", TxtYear.Text);
            cmd.Parameters.AddWithValue("@cgpa", TxtCGPA.Text);
            cmd.Parameters.AddWithValue("@email", TxtEmail.Text);


            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
                MessageBox.Show("Student updated successfully");
            else
                MessageBox.Show("Student not found");
        }


        public void deleteRecord()
        {
            string query = @"DELETE FROM student
                     WHERE StudentID = @id";

            conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", comboBox1.Text);

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
                MessageBox.Show("Record deleted successfully");
            else
                MessageBox.Show("Student not found");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
