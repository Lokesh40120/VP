using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Database
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "";
            string pwd = "";
            username = txtUsername.Text.Trim();
            pwd = txtPassword.Text.Trim();
            MessageBox.Show(username + " :::::::::::::::: " + pwd);
            if(username=="admin" && pwd=="admin123")
            {
                //MessageBox.Show("HAHAHAHA!!!!!..........\n", "Login Sucessful!!");
                Form1 fm1=new Form1();
                fm1.Show();
            }
            else
            {
                MessageBox.Show("HAHAHAHA!!!!!..........\n", "Login Failed!!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cyperText = Enc.Encrypt(textBox1.Text);
            textBox1.Text = cyperText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string plainText = Enc.Decrypt(textBox1.Text);
                textBox1.Text = plainText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while decrypting text.", "Decryption Error");
            }
        }
    }
}
