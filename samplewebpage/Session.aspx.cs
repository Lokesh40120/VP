using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sample
{
    public partial class Sessionhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["username"] = TextBox1.Text.Trim();
            Session["role"] = TextBox2.Text.Trim();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Write(Session.Timeout);
            //Session.Remove("role");
            Session.RemoveAll();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Remove("role");
        }
    }
}