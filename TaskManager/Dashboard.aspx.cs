using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace TaskManager
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getStudents();
        }
        public void getStudents()
        {
            try
            {
                string cs = ConfigurationManager
                 .ConnectionStrings["MySQLConnection"]
                 .ConnectionString;

                string query = "SELECT * FROM Stud ";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                string result = "";

                while (dr.Read())
                {
                    result += "StudentID: " + dr["StudentID"] + " - Name: " + dr["Name"] + "<hr/>";
                }

                if (result == "")
                {
                    Label1.Text = "No students found.";
                }
                else
                {
                    Label1.Text = result;
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message.ToString();
            }
        }
        public void getStudentById()
        {
            try
            {
                string cs = ConfigurationManager
                 .ConnectionStrings["MySQLConnection"]
                 .ConnectionString;

                string query = "SELECT * FROM Stud ";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                string result = "";

                while (dr.Read())
                {
                    result += "StudentID: " + dr["StudentID"] + " - Name: " + dr["Name"] + "<hr/>";
                }

                if (result == "")
                {
                    Label1.Text = "No students found.";
                }
                else
                {
                    Label1.Text = result;
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            getStudentById();
        }
    }
}