using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text == "admin" && TextBox2.Text == "admin123")
            {
                Session["username"] = TextBox1.Text;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}