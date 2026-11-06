using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSampleCrud
{
    public partial class Form3 : Form
    {
        private Control _webViewControlAdmin;
        private Control _webViewControlBrowser;
        public Form3()
        {
            InitializeComponent();
            InitializeWebView2IfAvailable();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnGo_Click(sender, EventArgs.Empty);
            }
        }

        private void txtBrowserAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBrowserGo_Click(sender, EventArgs.Empty);
            }
        }

        private void InitializeWebView2IfAvailable()
        {
            // Try to create WebView2 dynamically via reflection so project builds even if the NuGet isn't installed.
            try
            {
                var webViewType = Type.GetType("Microsoft.Web.WebView2.WinForms.WebView2, Microsoft.Web.WebView2.WinForms");
                if (webViewType != null)
                {
                    // create admin webview
                    var webViewAdmin = Activator.CreateInstance(webViewType) as Control;
                    if (webViewAdmin != null)
                    {
                        webViewAdmin.Dock = DockStyle.Fill;
                        this.panelWebHost.Controls.Clear();
                        this.panelWebHost.Controls.Add(webViewAdmin);
                        _webViewControlAdmin = webViewAdmin;
                    }

                    // create browser webview
                    var webViewBrowser = Activator.CreateInstance(webViewType) as Control;
                    if (webViewBrowser != null)
                    {
                        webViewBrowser.Dock = DockStyle.Fill;
                        this.panelBrowserHost.Controls.Clear();
                        this.panelBrowserHost.Controls.Add(webViewBrowser);
                        _webViewControlBrowser = webViewBrowser;
                    }
                }
                else
                {
                    // Show a friendly message in the panels telling the user to install WebView2.
                    var lblAdmin = new Label()
                    {
                        Text = "WebView2 control not available. Install Microsoft.Web.WebView2 via NuGet and ensure WebView2 runtime is installed.",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.White,
                        BackColor = Color.DarkGray
                    };
                    this.panelWebHost.Controls.Clear();
                    this.panelWebHost.Controls.Add(lblAdmin);

                    var lblBrowser = new Label()
                    {
                        Text = "WebView2 control not available. Install Microsoft.Web.WebView2 via NuGet and ensure WebView2 runtime is installed.",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.White,
                        BackColor = Color.DarkGray
                    };
                    this.panelBrowserHost.Controls.Clear();
                    this.panelBrowserHost.Controls.Add(lblBrowser);
                }
            }
            catch (Exception ex)
            {
                var lbl = new Label()
                {
                    Text = "Error initializing WebView2: " + ex.Message,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    BackColor = Color.DarkGray
                };
                this.panelWebHost.Controls.Clear();
                this.panelWebHost.Controls.Add(lbl);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var url = txtAddress.Text?.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a URL.");
                return;
            }

            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                url = "https://" + url;

            if (_webViewControlAdmin != null)
            {
                // Try to call Navigate(string) via reflection
                try
                {
                    var navigateMethod = _webViewControlAdmin.GetType().GetMethod("Navigate", new[] { typeof(string) });
                    if (navigateMethod != null)
                    {
                        navigateMethod.Invoke(_webViewControlAdmin, new object[] { url });
                    }
                    else
                    {
                        MessageBox.Show("WebView control does not expose Navigate(string).");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to navigate: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("WebView2 is not available. Install Microsoft.Web.WebView2 NuGet and the WebView2 runtime.");
            }
        }

        private void btnBrowserGo_Click(object sender, EventArgs e)
        {
            var url = txtBrowserAddress.Text?.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a URL.");
                return;
            }

            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                url = "https://" + url;

            if (_webViewControlBrowser != null)
            {
                try
                {
                    var navigateMethod = _webViewControlBrowser.GetType().GetMethod("Navigate", new[] { typeof(string) });
                    if (navigateMethod != null)
                    {
                        navigateMethod.Invoke(_webViewControlBrowser, new object[] { url });
                    }
                    else
                    {
                        MessageBox.Show("WebView control does not expose Navigate(string)."
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to navigate: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("WebView2 is not available. Install Microsoft.Web.WebView2 NuGet and the WebView2 runtime.");
            }
        }
    }
}
