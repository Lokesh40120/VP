using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace marks
{
    public partial class hi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                string extension = Path.GetExtension(FileUpload1.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                if(Array.IndexOf(allowedExtensions, extension) == -1)
                {
                    Label1.Text = "Upload a valid image file (JPG, JPEG, PNG, GIF)";
                    return;
                }
                try
                {
                    {
                        string fileName = Guid.NewGuid().ToString() + extension;
                        string folder=Server.MapPath("~/uploads/");
                        Directory.CreateDirectory(folder);
                        string path = Path.Combine(folder, fileName);
                        FileUpload1.SaveAs(path);
                        Image1.ImageUrl = "~/uploads/" + fileName;
                        Label1.Text= "Image uploaded successfully!";
                    }
                }
                catch
                {
                    Label1.Text = "Invalid image file.";
                }
            }
            else
            {
                Label1.Text = "Please select an image.";
            }
        }
    }
}