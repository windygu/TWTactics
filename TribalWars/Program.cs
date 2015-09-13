using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using TribalWars.Forms;

namespace TribalWars
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			try
			{
				var ci = CultureInfo.GetCultureInfo(Properties.Settings.Default.Culture);
				Thread.CurrentThread.CurrentCulture = ci;
				Thread.CurrentThread.CurrentUICulture = ci;
			}
			catch
			{
				Properties.Settings.Default.Culture = "";
				Properties.Settings.Default.Save();
			}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}