using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (text == "")
                return;

            if (text.Contains(".") && !text.Contains(" "))
            {
                if (!text.StartsWith("http://") &&
                    !text.StartsWith("https://"))
                {
                    text = "https://" + text;
                }
            }
            else
            {
                text = "https://www.google.com/search?q=" +
                       Uri.EscapeDataString(text);
            }

            webView21.Source = new Uri(text);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
