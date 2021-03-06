﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Reflection;

namespace UOMachine
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    internal partial class About : Window
    {
        private static DropShadowEffect myDropShadow;
        private bool myCancelEnabled = true;
        public bool CancelEnabled
        {
            get { return Utility.ThreadHelper.VolatileRead<bool>(ref myCancelEnabled); }
            internal set {  myCancelEnabled = value;}
        }

        public About()
        {
            InitializeComponent();
            textBlock1.Text = VersionInfo;
            myDropShadow = new DropShadowEffect();
            myDropShadow.Opacity = 1;
            myDropShadow.ShadowDepth = 0;
            myDropShadow.BlurRadius = 8;
            myDropShadow.Color = Colors.Red;
            this.Closing += new System.ComponentModel.CancelEventHandler(About_Closing);
            textBox1.Text = Properties.Resources.Credits;
        }

        private void About_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.CancelEnabled)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void textBlock5_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Reetus/UOMachine");
        }

        private void textBlock5_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlock5.Effect = myDropShadow;

        }

        private void textBlock5_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlock5.Effect = null;
        }

        public string VersionInfo
        {
            get {
                Version ver = Assembly.GetExecutingAssembly().GetName().Version;
                return String.Format("UOMachine {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
        }
    }
}
