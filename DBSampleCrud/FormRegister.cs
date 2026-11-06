using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBSampleCrud
{
    public partial class FormRegister : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=students;Uid=root;Pwd=Mari1410$;";

        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var user = txtUserId.Text?.Trim();
            var pass = txtPassword.Text ?? string.Empty;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter user id and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // check if user exists
                    using (var checkCmd = conn.CreateCommand())
                    {
                        checkCmd.CommandText = "SELECT COUNT(1) FROM students.usermaster WHERE userid = @user";
                        checkCmd.Parameters.AddWithValue("@user", user);
                        var exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                        if (exists)
                        {
                            MessageBox.Show("User already exists.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // insert encrypted password
                    using (var insertCmd = conn.CreateCommand())
                    {
                        insertCmd.CommandText = "INSERT INTO students.usermaster (userid, password) VALUES (@user, @pass)";
                        insertCmd.Parameters.AddWithValue("@user", user);
                        insertCmd.Parameters.AddWithValue("@pass", Encryption.Encrypt(pass));
                        var rows = insertCmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("User registered successfully.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
