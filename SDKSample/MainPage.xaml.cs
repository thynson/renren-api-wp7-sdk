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
using RenrenSDKLibrary;

namespace SDKSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        RenrenAPI api = App.api;
        // Constructor
        public MainPage()
        {
            InitializeComponent();   
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Authored_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(api.IsAccessTokenValid())
            {
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml", UriKind.Relative));
            }
            else
            {
                api.Login(this, renren_LoginCompletedHandler);
            }
        }

        private void ExtentAuthored_Btn_Click(object sender, RoutedEventArgs e)
        {
            List<string> scope = new List<string> { "publish_feed", "publish_blog", "read_user_album", "create_album", "photo_upload" };
            if (api.IsAccessTokenValid())
            {
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml", UriKind.Relative));
            }
            else
            {
                api.Login(this, scope, renren_LoginCompletedHandler);
            }
        }

        private void NameAndPaswd_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (api.IsAccessTokenValid())
            {
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/Views/LoginPage.xaml", UriKind.Relative));
            }
        }

        private void WebControl_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (api.IsAccessTokenValid())
            {
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/Views/WebControlLoginPage.xaml", UriKind.Relative));
            }
        }

        public void renren_LoginCompletedHandler(object sender, LoginCompletedEventArgs e)
        {
            if (e.Error == null)
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml", UriKind.Relative));
            else
                MessageBox.Show(e.Error.Message);
        }
    }
}