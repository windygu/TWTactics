﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TribalWars.Tools;

namespace TribalWars.Forms.Small
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            labelProductName.Text = String.Format("{0}", AssemblyTitle);
            labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            textBoxDescription.Text = AssemblyDescription;
            SetTitle();
        }

        private void SetTitle()
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.RegistratedTo))
            {
                Text = string.Format("TW Tactics - Registered to {0}!", Properties.Settings.Default.RegistratedTo);
            }
        }

        private void VerifyProductKey_Click(object sender, EventArgs e)
        {
            try
            {
                string registrator = Network.GetWebRequest("http://www.sangu.be/api/registertactics.php?key=" + ProductKey.Text);
                if (!string.IsNullOrWhiteSpace(registrator))
                {
                    Properties.Settings.Default.RegistratedTo = registrator;
                    Properties.Settings.Default.Save();
                    SetTitle();

                    MessageBox.Show(string.Format("All super illegal features are now unlocked!\n\n... Nah, just kidding, thanks for the card!", registrator), "Owh yeah", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Product key does not seem to be valid!?", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Looks like there was a problem while trying to verify your key.");
            }
        }

        private void OfficialSiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var sInfo = new ProcessStartInfo(((LinkLabel)sender).Text);
            Process.Start(sInfo);
        }

        private void SourceControlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var sInfo = new ProcessStartInfo(((LinkLabel)sender).Text);
            Process.Start(sInfo);
        }

        #region Assembly Attribute Accessors
        public static string ProgramVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return string.Format("{0}.{1}", version.Major, version.Minor);
            }
        }

        private static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        private static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        #endregion

        private void License_Click(object sender, EventArgs e)
        {
            const string license = @"TW Tactics
MIT License

Copyright (c) 2015-2017 Wouter Van Schandevijl

Permission is hereby granted, free of charge, to any person obtaining a copy of this software
and associated documentation files (the ""Software""), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";

            MessageBox.Show(license, "MIT License", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
