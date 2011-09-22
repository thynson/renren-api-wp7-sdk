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
using Microsoft.Phone.Shell;
using RenrenSDKLibrary;

namespace SDKSample
{
    public partial class FriendsList : PhoneApplicationPage
    {
        RenrenAPI api = App.api;
        public FriendsList()
        {
            InitializeComponent();
        }

        private void Inquiry_Btn_Click(object sender, RoutedEventArgs e)
        {
            disableRect.Visibility = Visibility.Visible;
            down_Bar.Visibility = Visibility.Visible;
            down_TBlk.Visibility = Visibility.Visible;
            /// scope为支持的额外参数，现在仅支持以下额外参数 headurl_with_logo，tinyurl_with_logo
            List<string> scope = new List<string>() ;
            scope.Add("headurl_with_logo");
             scope.Add("tinyurl_with_logo");
            if (count_TBox.Text == "" || page_TBox.Text =="")
                api.GetFriends(renren_GetFriendsCompletedHandler);
            else
                api.GetFriends(renren_GetFriendsCompletedHandler, Convert.ToInt32(count_TBox.Text), Convert.ToInt32(page_TBox.Text));  
            
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }

        public void renren_GetFriendsCompletedHandler(object sender, GetFriendsCompletedEventArgs e)
        {
            disableRect.Visibility = Visibility.Collapsed;
            down_Bar.Visibility = Visibility.Collapsed;
            down_TBlk.Visibility = Visibility.Collapsed;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                NavigationService.GoBack();
            }
            else
            {

                FriendList_LBox.ItemsSource = e.Result;
            }
                
        }

        private void Clean_Btn_Click(object sender, RoutedEventArgs e)
        {
            FriendList_LBox.ItemsSource = null;
        }

    }
}