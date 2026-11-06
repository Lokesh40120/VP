using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace samplewebpage
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Click Me button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(
                "Welcome to my website! <br />" +
                "<h1> V R GRT </h1>" +
                TextBox1.Text +
                "<script>alert('Button clicked successfully!');</script>"
            );
        }

        // Fetch Value button
        protected void Button2_Click(object sender, EventArgs e)
        {
            string result = "";

            // Label
            result += "Label: " + Label1.Text + "<br />";

            // TextBox
            result += "Text Box: " + TextBox1.Text + "<br />";

            // Drop Down List 1
            result += "Drop Down 1: " +
                      DropDownList1.SelectedItem.Text + "<br />";

            // Drop Down List 2
            result += "Drop Down 2: " +
                      DropDownList2.SelectedItem.Text + "<br />";

            // Check Boxes
            result += "Check Boxes: ";

            if (CheckBox1.Checked)
            {
                result += "VP ";
            }

            if (CheckBox2.Checked)
            {
                result += "DTSP ";
            }

            if (CheckBox3.Checked)
            {
                result += "OOPs ";
            }

            if (!CheckBox1.Checked &&
                !CheckBox2.Checked &&
                !CheckBox3.Checked)
            {
                result += "None";
            }

            result += "<br />";

            // Radio Buttons
            if (RadioButton1.Checked)
            {
                result += "Radio Button: UG<br />";
            }
            else if (RadioButton2.Checked)
            {
                result += "Radio Button: PG<br />";
            }
            else
            {
                result += "Radio Button: None<br />";
            }

            // Calendar
            if (Calendar1.SelectedDate != DateTime.MinValue)
            {
                result += "Selected Date: " +
                          Calendar1.SelectedDate.ToString("dd-MM-yyyy") +
                          "<br />";
            }
            else
            {
                result += "Selected Date: None<br />";
            }

            // Display result
            Label2.Text = result;
        }
    }
}