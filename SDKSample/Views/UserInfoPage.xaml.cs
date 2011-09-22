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
    public partial class UserInfoPage : PhoneApplicationPage
    {
        RenrenAPI api = App.api;
        public UserInfoPage()
        {
            InitializeComponent();
        }

        private void GetUserInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            disableRect.Visibility = Visibility.Visible;
            down_Bar.Visibility = Visibility.Visible;
            down_TBlk.Visibility = Visibility.Visible;
           // string field = "uid,name,sex,star,zidou,vip,birthday,email_hash,tinyurl,headurl,mainurl,hometown_location,work_history,university_history";
            List<string> scope = new List<string>();
            scope.Add("uid");
            scope.Add("name");
            scope.Add("sex");
            scope.Add("star");
            scope.Add("zidou");
            scope.Add("vip");
            scope.Add("birthday");
            scope.Add("email_hash");
            scope.Add("tinyurl");
            scope.Add("headurl");
            scope.Add("mainurl");
            scope.Add("hometown_location");
            scope.Add("work_history");
            scope.Add("university_history");
            if(txb_Uids.Text != null)
            {
                api.GetUserInfo(txb_Uids.Text, scope, renren_GetUserInfoCompletedHandler);
            }
           
        }

        public void renren_GetUserInfoCompletedHandler(object sender, GetUsersCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
                NavigationService.GoBack();
            }
            else
            {
                disableRect.Visibility = Visibility.Collapsed;
                down_Bar.Visibility = Visibility.Collapsed;
                down_TBlk.Visibility = Visibility.Collapsed;
                UserList_Box.ItemsSource = e.Result.User_List;
            }
                 
        }

        private void txb_Uids_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txb_Uids.Text = "";
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }
    }
}