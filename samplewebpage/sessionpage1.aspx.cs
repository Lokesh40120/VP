using System;
using System.Web.UI;

namespace samplewebpage
{
    public partial class sessionpage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Welcome " + Session["username"] + " " + Session["role"];
        }
    }
}