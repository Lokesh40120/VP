namespace DBSampleCrud
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            // Tab control with 4 tabs: User, Admin, Guest, Browser
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.tabGuest = new System.Windows.Forms.TabPage();
            this.tabBrowser = new System.Windows.Forms.TabPage();

            // Controls for admin tab (address bar, go button, and panel to host WebView2)
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.panelWebHost = new System.Windows.Forms.Panel();

            // TabControl
            this.tabControl1.Controls.Add(this.tabUser);
            this.tabControl1.Controls.Add(this.tabAdmin);
            this.tabControl1.Controls.Add(this.tabGuest);
            this.tabControl1.Controls.Add(this.tabBrowser);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Size = new System.Drawing.Size(760, 440);
            this.tabControl1.SelectedIndex = 0;

            // tabUser
            this.tabUser.Text = "User";
            this.tabUser.BackColor = System.Drawing.Color.LightBlue;

            // tabAdmin
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.BackColor = System.Drawing.Color.LightGreen;
            // address bar and go button at top of admin tab
            this.txtAddress.Location = new System.Drawing.Point(10, 10);
            this.txtAddress.Size = new System.Drawing.Size(600, 22);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            this.btnGo.Location = new System.Drawing.Point(620, 8);
            this.btnGo.Size = new System.Drawing.Size(75, 26);
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // panel to host WebView2
            this.panelWebHost.Location = new System.Drawing.Point(10, 44);
            this.panelWebHost.Size = new System.Drawing.Size(740, 380);
            this.panelWebHost.BackColor = System.Drawing.Color.Black;
            this.tabAdmin.Controls.Add(this.txtAddress);
            this.tabAdmin.Controls.Add(this.btnGo);
            this.tabAdmin.Controls.Add(this.panelWebHost);

            // tabGuest
            this.tabGuest.Text = "Guest";
            this.tabGuest.BackColor = System.Drawing.Color.LightYellow;

            // tabBrowser
            this.tabBrowser.Text = "Browser";
            this.tabBrowser.BackColor = System.Drawing.Color.LightCoral;
            // Browser tab address bar, go button and panel
            this.txtBrowserAddress = new System.Windows.Forms.TextBox();
            this.btnBrowserGo = new System.Windows.Forms.Button();
            this.panelBrowserHost = new System.Windows.Forms.Panel();
            this.txtBrowserAddress.Location = new System.Drawing.Point(10, 10);
            this.txtBrowserAddress.Size = new System.Drawing.Size(600, 22);
            this.txtBrowserAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrowserAddress_KeyDown);
            this.btnBrowserGo.Location = new System.Drawing.Point(620, 8);
            this.btnBrowserGo.Size = new System.Drawing.Size(75, 26);
            this.btnBrowserGo.Text = "Go";
            this.btnBrowserGo.Click += new System.EventHandler(this.btnBrowserGo_Click);
            this.panelBrowserHost.Location = new System.Drawing.Point(10, 44);
            this.panelBrowserHost.Size = new System.Drawing.Size(740, 380);
            this.panelBrowserHost.BackColor = System.Drawing.Color.Black;
            this.tabBrowser.Controls.Add(this.txtBrowserAddress);
            this.tabBrowser.Controls.Add(this.btnBrowserGo);
            this.tabBrowser.Controls.Add(this.panelBrowserHost);

            this.Controls.Add(this.tabControl1);
            this.Text = "Form3";
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.TabPage tabGuest;
        private System.Windows.Forms.TabPage tabBrowser;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panelWebHost;
        private System.Windows.Forms.TextBox txtBrowserAddress;
        private System.Windows.Forms.Button btnBrowserGo;
        private System.Windows.Forms.Panel panelBrowserHost;
    }
}