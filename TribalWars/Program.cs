using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
            // TODO: Add error handling; send log entries to sangu.be?
            // TODO: Check if has write access to the current directory?

			//try
			//{
				try
				{
					var ci = CultureInfo.GetCultureInfo(Properties.Settings.Default.Culture);
				    if (ci.Name == "")
				    {
				        ci = new CultureInfo("en-US");
				    }
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
			//}
			//catch (Exception ex)
			//{
			//	File.WriteAllText(@"c:\Users\vagrant\Desktop\TWTactics\twtactics.txt", ex.ToString());
			//	MessageBox.Show(ex.ToString(), "oepsie");
			//}
		}
	}
}