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
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            Login_Btn.Visibility = Visibility.Collapsed;
            login_Bar.Visibility = Visibility.Visible;
            login_TBlk.Visibility = Visibility.Visible;

            api.Login(Name_TBox.Text, Passwd_TBox.Password, renren_LoginCompletedHandler);

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
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml?prepage=passwordpage", UriKind.Relative));
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