using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cef
{
    static class Program
    {
        public static Form1 mainForm;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var setting = new CefSharp.CefSettings();
            setting.Locale = "zh-CN";
            setting.CachePath = "cache";
            CefSharp.Cef.Initialize(setting);

            Application.Run(mainForm = new Form1());

            CefSharp.Cef.Shutdown();
        }
    }
}
