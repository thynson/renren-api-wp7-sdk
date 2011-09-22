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
    public partial class AppFriendsListPage : PhoneApplicationPage
    {
        RenrenAPI api = App.api;
        public AppFriendsListPage()
        {
            InitializeComponent();
        }

        private void InquiryID_Btn_Click(object sender, RoutedEventArgs e)
        {
            disableRect.Visibility = Visibility.Visible;
            down_Bar.Visibility = Visibility.Visible;
            down_TBlk.Visibility = Visibility.Visible;
            ///直接调用 GetAppFriends,不带额外参数，此时返回一个List<int>，为appfriends的id。
            api.GetAppFriends(renren_GetAppFriendsIDCompletedHandler);
        }

        public void renren_GetAppFriendsIDCompletedHandler(object sender, GetAppFriendsIDCompletedEventArgs e)
        {
            disableRect.Visibility = Visibility.Collapsed;
            down_Bar.Visibility = Visibility.Collapsed;
            down_TBlk.Visibility = Visibility.Collapsed;
            AppFriendList_LBox.Visibility = Visibility.Collapsed;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                NavigationService.GoBack();
            }
            else
            {
                AppFriendIDList_LBox.Visibility = Visibility.Visible;
                AppFriendIDList_LBox.FontSize = 30;
                AppFriendIDList_LBox.ItemsSource = e.Result;
            }
        }

        private void BasicInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            disableRect.Visibility = Visibility.Visible;
            down_Bar.Visibility = Visibility.Visible;
            down_TBlk.Visibility = Visibility.Visible;
            /// 调用 GetAppFriends 时传入 scope 额外参数，支持以下参数，name，tinyurl，headurl
            List<string> scope = new List<string>();
            scope.Add("name");
            scope.Add("tinyurl");
            scope.Add("headurl");
            AppFriendList_LBox.ItemTemplate = App.Current.Resources["AppFriendsListTemplate"] as DataTemplate;
            api.GetAppFriends(scope, renren_GetAppFriendsCompletedHandler);
        }

        public void renren_GetAppFriendsCompletedHandler(object sender, GetAppFriendsCompletedEventArgs e)
        {
            disableRect.Visibility = Visibility.Collapsed;
            down_Bar.Visibility = Visibility.Collapsed;
            down_TBlk.Visibility = Visibility.Collapsed;
            AppFriendIDList_LBox.Visibility = Visibility.Collapsed;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                NavigationService.GoBack();
            }
            else
            {
                AppFriendList_LBox.Visibility = Visibility.Visible;
                AppFriendList_LBox.ItemsSource = e.Result;
            }
        }



        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }
    }
}