using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace cef
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();

            browser = new ChromiumWebBrowser("http://www.abelliu.com");

            browser.Dock = DockStyle.Fill;
            this.panelBottom.Controls.Add(browser);

            browser.FrameLoadEnd += Browser_FrameLoadEnd;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var obj = new BoundObject();
            browser.RegisterJsObject("bound", obj);
        }

        private void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                browser.ExecuteScriptAsync(@"
                document.body.onmouseup = function() {
                    bound.onSelected(window.getSelection().toString());
                }");
            }
        }

        public void ShowJsResult(string message)
        {
            this.Invoke(new Action(() => { this.richTextBox1.Text = message; }));
        }

    }

    public class BoundObject
    {
        public void OnSelected(string selectedText)
        {
            Program.mainForm.ShowJsResult(selectedText);
        }
    }

}
