using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBSampleCrud
{
    public partial class Form2 : Form
    {
        // Adjust connection string if you use a different DB user or password
        private readonly string connectionString = "Server=localhost;Port=3306;Database=students;Uid=root;Pwd=Mari1410$;";

        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = txtUsername.Text?.Trim();
            var pass = txtPassword.Text?.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter username and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        // retrieve the stored (encrypted) password for the given userid
                        cmd.CommandText = "SELECT password FROM students.usermaster WHERE userid = @user LIMIT 1";
                        cmd.Parameters.AddWithValue("@user", user);

                        var result = cmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            // user not found
                        }
                        else
                        {
                            var storedEncrypted = result.ToString();
                            try
                            {
                                var storedPlain = Encryption.Decrypt(storedEncrypted);
                                if (storedPlain == pass)
                                {
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                    return;
                                }
                            }
                            catch (FormatException)
                            {
                                // stored value is not a valid base64 / encrypted value
                            }
                            catch (Exception ex)
                            {
                                // decryption error — show for debugging
                                MessageBox.Show("Decryption error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var input = txtCryptoInput.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Enter text to encrypt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                txtCryptoOutput.Text = Encryption.Encrypt(input);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encryption failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            var input = txtCryptoInput.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Enter text to decrypt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                txtCryptoOutput.Text = Encryption.Decrypt(input);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decryption failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var reg = new FormRegister())
            {
                reg.ShowDialog(this);
            }
        }
    }
}
