using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        // =========================================================
        // DATABASE CONNECTION
        // =========================================================

        private const string connectionString =
            "server=localhost;user=root;password=monkey;database=section51_db;port=3306;";


        // =========================================================
        // FORM CONSTRUCTOR
        // =========================================================

        public Form1()
        {
            InitializeComponent();
        }


        // =========================================================
        // FORM LOAD
        // =========================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudentID();
            LoadDataGrid();

            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";

            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";

            ClearUpdateFields();
        }


        // =========================================================
        // RESET ADD FORM
        // =========================================================

        private void Button1_Click(object sender, EventArgs e)
        {
            ResetAll();
        }


        private void ResetAll()
        {
            txtid.Clear();
            txtname.Clear();
            txtdepartment.Clear();
            txtyear.Clear();
            txtcgpa.Clear();

            txtid.Focus();
        }


        // =========================================================
        // ADD BUTTON
        // =========================================================

        private void BtnADD_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }


        // =========================================================
        // INSERT RECORD
        // =========================================================

        private void InsertRecord()
        {
            try
            {
                // Check empty fields
                if (txtid.Text.Trim() == "" ||
                    txtname.Text.Trim() == "" ||
                    txtdepartment.Text.Trim() == "" ||
                    txtyear.Text.Trim() == "" ||
                    txtcgpa.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Please enter all student details.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // Validate Student ID
                int studentID;

                if (!int.TryParse(txtid.Text.Trim(), out studentID))
                {
                    MessageBox.Show(
                        "Student ID must be a number.",
                        "Invalid Student ID",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // Validate Year
                int year;

                if (!int.TryParse(txtyear.Text.Trim(), out year))
                {
                    MessageBox.Show(
                        "Year must be a number.",
                        "Invalid Year",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // Validate CGPA
                decimal cgpa;

                if (!decimal.TryParse(txtcgpa.Text.Trim(), out cgpa))
                {
                    MessageBox.Show(
                        "CGPA must be a number.",
                        "Invalid CGPA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                string query = @"
                    INSERT INTO Stud
                    (
                        StudentID,
                        Name,
                        Department,
                        Year,
                        CGPA
                    )
                    VALUES
                    (
                        @id,
                        @name,
                        @dept,
                        @year,
                        @cgpa
                    )";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            studentID);

                        cmd.Parameters.AddWithValue(
                            "@name",
                            txtname.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@dept",
                            txtdepartment.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@year",
                            year);

                        cmd.Parameters.AddWithValue(
                            "@cgpa",
                            cgpa);

                        cmd.ExecuteNonQuery();
                    }
                }


                MessageBox.Show(
                    "Student inserted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                ResetAll();

                LoadStudentID();
                LoadDataGrid();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show(
                        "Student ID already exists.",
                        "Duplicate Student ID",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "MySQL Error:\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Insert Error:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // LOAD STUDENT IDs
        // =========================================================

        private void LoadStudentID()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();


                string query =
                    "SELECT StudentID FROM Stud ORDER BY StudentID";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader =
                               cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id =
                                    reader["StudentID"].ToString();

                                comboBox1.Items.Add(id);
                                comboBox2.Items.Add(id);
                            }
                        }
                    }
                }


                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "";

                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "";

                ClearUpdateFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Load ID Error:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // LOAD DATA GRID
        // =========================================================

        private void LoadDataGrid()
        {
            try
            {
                string query = @"
                    SELECT
                        StudentID,
                        Name,
                        Department,
                        Year,
                        CGPA
                    FROM Stud
                    ORDER BY StudentID";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlDataAdapter da =
                           new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt =
                            new DataTable();

                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Load Data Error:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // DEPARTMENT FILTER BUTTON
        // =========================================================

        private void Button2_Click(object sender, EventArgs e)
        {
            FilterByDepartment();
        }


        // =========================================================
        // FILTER BY DEPARTMENT
        // =========================================================

        private void FilterByDepartment()
        {
            try
            {
                string selectedValue =
                    comboBox1.Text.Trim();


                // If nothing is selected
                if (selectedValue == "")
                {
                    LoadDataGrid();
                    return;
                }


                // Find department of selected Student ID
                string departmentQuery = @"
                    SELECT Department
                    FROM Stud
                    WHERE StudentID = @id";


                string department = "";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand(
                               departmentQuery,
                               conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            selectedValue);

                        object result =
                            cmd.ExecuteScalar();

                        if (result != null)
                        {
                            department =
                                result.ToString();
                        }
                    }
                }


                if (department == "")
                {
                    MessageBox.Show(
                        "Department not found.",
                        "Filter",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                string query = @"
                    SELECT
                        StudentID,
                        Name,
                        Department,
                        Year,
                        CGPA
                    FROM Stud
                    WHERE Department = @dept
                    ORDER BY StudentID";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@dept",
                            department);

                        using (MySqlDataAdapter da =
                               new MySqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();

                            da.Fill(dt);

                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Department Filter Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // UPDATE STUDENT ID COMBOBOX
        // =========================================================

        private void comboBox2_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1 ||
                comboBox2.Text.Trim() == "")
            {
                ClearUpdateFields();
                return;
            }


            LoadSelectedStudent(
                comboBox2.Text.Trim());
        }


        // =========================================================
        // LOAD SELECTED STUDENT
        // =========================================================

        private void LoadSelectedStudent(
            string studentID)
        {
            try
            {
                string query = @"
                    SELECT
                        Name,
                        Department,
                        Year,
                        CGPA
                    FROM Stud
                    WHERE StudentID = @id";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            studentID);

                        using (MySqlDataReader reader =
                               cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox2.Text =
                                    reader["Name"].ToString();

                                textBox3.Text =
                                    reader["Department"].ToString();

                                textBox4.Text =
                                    reader["Year"].ToString();

                                textBox5.Text =
                                    reader["CGPA"].ToString();
                            }
                            else
                            {
                                ClearUpdateFields();

                                MessageBox.Show(
                                    "Student not found.",
                                    "Search",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Student Load Error:\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // UPDATE BUTTON
        // =========================================================

        private void BtnUpdate_Click(
            object sender,
            EventArgs e)
        {
            UpdateRecord();
        }


        // =========================================================
        // UPDATE RECORD
        // =========================================================

        private void UpdateRecord()
        {
            try
            {
                string studentID =
                    comboBox2.Text.Trim();


                if (studentID == "")
                {
                    MessageBox.Show(
                        "Please select Student ID from the dropdown.",
                        "Select Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                if (textBox2.Text.Trim() == "" ||
                    textBox3.Text.Trim() == "" ||
                    textBox4.Text.Trim() == "" ||
                    textBox5.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Please fill all update fields.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                int year;

                if (!int.TryParse(
                        textBox4.Text.Trim(),
                        out year))
                {
                    MessageBox.Show(
                        "Year must be a number.",
                        "Invalid Year",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                decimal cgpa;

                if (!decimal.TryParse(
                        textBox5.Text.Trim(),
                        out cgpa))
                {
                    MessageBox.Show(
                        "CGPA must be a number.",
                        "Invalid CGPA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                string query = @"
                    UPDATE Student
                    SET
                        Name = @name,
                        Department = @dept,
                        Year = @year,
                        CGPA = @cgpa
                    WHERE StudentID = @id";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            studentID);

                        cmd.Parameters.AddWithValue(
                            "@name",
                            textBox2.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@dept",
                            textBox3.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@year",
                            year);

                        cmd.Parameters.AddWithValue(
                            "@cgpa",
                            cgpa);


                        int rows =
                            cmd.ExecuteNonQuery();


                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Student updated successfully.",
                                "Update Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Student not found.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }


                LoadStudentID();
                LoadDataGrid();

                ClearUpdateFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Update Error:\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // DELETE BUTTON
        // =========================================================

        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {
            DeleteRecord();
        }


        // =========================================================
        // DELETE RECORD
        // =========================================================

        private void DeleteRecord()
        {
            try
            {
                string studentID =
                    comboBox2.Text.Trim();


                if (studentID == "")
                {
                    MessageBox.Show(
                        "Please select Student ID.",
                        "Select Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete Student ID "
                        + studentID + "?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);


                if (result != DialogResult.Yes)
                {
                    return;
                }


                string query =
                    "DELETEfrom stud WHERE StudentID = @id";


                using (MySqlConnection conn =
                       new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            studentID);

                        int rows =
                            cmd.ExecuteNonQuery();


                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Student deleted successfully.",
                                "Delete Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Student not found.",
                                "Delete Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }


                ClearUpdateFields();

                LoadStudentID();
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Delete Error:\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CLEAR UPDATE FIELDS
        // =========================================================

        private void ClearUpdateFields()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }


        // =========================================================
        // REFRESH BUTTON
        // =========================================================

        private void Button3_Click(
            object sender,
            EventArgs e)
        {
            LoadStudentID();
            LoadDataGrid();

            ClearUpdateFields();
        }


        // =========================================================
        // FORM DIALOG
        // =========================================================

        private void FormDialog_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using (Form3 form3 =
                       new Form3())
                {
                    form3.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Form3:\n" +
                    ex.Message,
                    "Navigation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // FORM SHOW
        // =========================================================

        private void FormShow_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Form3 form3 =
                    new Form3();

                form3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Form3:\n" +
                    ex.Message,
                    "Navigation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // BUTTON 4
        // =========================================================

        private void Button4_Click(
            object sender,
            EventArgs e)
        {
            FormShow_Click(sender, e);
        }


        // =========================================================
        // DATAGRIDVIEW EVENT
        // =========================================================

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }


        // =========================================================
        // GROUPBOX EVENT
        // =========================================================

        private void groupBox1_Enter(
            object sender,
            EventArgs e)
        {
        }


        // =========================================================
        // LABEL EVENTS
        // =========================================================

        private void label4_Click(
            object sender,
            EventArgs e)
        {
        }


        private void addGroup_Enter(
            object sender,
            EventArgs e)
        {
        }


        private void label2_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}