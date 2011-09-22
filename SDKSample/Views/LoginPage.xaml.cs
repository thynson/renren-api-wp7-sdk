//  Copyright 2011年 Renren Inc. All rights reserved.
//  - Powered by Team Pegasus. -

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using RenrenSDKLibrary;

namespace SDKSample
{
    public partial class LoginPage : PhoneApplicationPage
    {
        IsolatedStorageSettings setting = IsolatedStorageSettings.ApplicationSettings;
        RenrenAPI api = App.api;
        public LoginPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(LoginPage_Loaded);
        }

        void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (setting.Contains("name") && setting.Contains("passwd"))
            {
                Name_TBox.Text = setting["name"].ToString();
                Passwd_TBox.Password = setting["passwd"].ToString();
            }
        }

        private void Save_CBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Save_CBox.IsChecked == true)
            {
                if (setting.Contains("name") == false && setting.Contains("passwd") == false)
                {
                    setting.Add("name", Name_TBox.Text);
                    setting.Add("passwd", Passwd_TBox.Password);
                }
            }
            Login_Btn.Visibility = Visibility.Collapsed;
            login_Bar.Visibility = Visibility.Visible;
            login_TBlk.Visibility = Visibility.Visible;

            api.Login(Name_TBox.Text, Passwd_TBox.Password, "510991aed48945e4ae48f4481b33859c", renren_LoginCompletedHandler);

        }


        public void renren_LoginCompletedHandler(object sender,   LoginCompletedEventArgs e)
        {
            Login_Btn.Visibility = Visibility.Visible;
            login_Bar.Visibility = Visibility.Collapsed;
            login_TBlk.Visibility = Visibility.Collapsed;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }

            if (e.Result == "success")
            {
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml", UriKind.Relative));
            }
        }


        private void Passwd_TBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Passwd_TBox.Password = "";
        }

        private void Name_TBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name_TBox.Text = "";
        }
    }


}