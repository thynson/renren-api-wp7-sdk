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
    public partial class FriendsIDList : PhoneApplicationPage
    {
        RenrenAPI api = App.api;

        public FriendsIDList()
        {
            InitializeComponent();
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }

          private void Inquiry_Btn_Click(object sender, RoutedEventArgs e)
        {
            disableRect.Visibility = Visibility.Visible;
            down_Bar.Visibility = Visibility.Visible;
            down_TBlk.Visibility = Visibility.Visible;

            if (count_TBox.Text == "" || page_TBox.Text == "")
                api.GetFriendsID(renren_GetFriendsIDCompletedHandler);
            else
            {
                api.GetFriendsID(renren_GetFriendsIDCompletedHandler, Convert.ToInt32(count_TBox.Text), Convert.ToInt32(page_TBox.Text));  
            }
                
        }

          public void renren_GetFriendsIDCompletedHandler(object sender, GetFriendsIDCompletedEventArgs e)
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
                  FriendIDList_LBox.ItemsSource = e.Result;
              }
              
          }

          private void Clean_Btn_Click(object sender, RoutedEventArgs e)
          {
              FriendIDList_LBox.ItemsSource = null;
          }
 
    }
}