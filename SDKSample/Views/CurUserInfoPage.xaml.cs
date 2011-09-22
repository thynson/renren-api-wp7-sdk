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
using System.Collections.ObjectModel;


namespace SDKSample
{
    public partial class CurUserInfoPage : PhoneApplicationPage
    {
        RenrenAPI api = App.api;

        public CurUserInfoPage()
        {
            InitializeComponent();

           this.Loaded += new RoutedEventHandler(LoginPage_Loaded);
        }

        void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            api.GetCurUserInfo(renren_GetCurUserInfoCompletedHandler);
        }
        public void renren_GetCurUserInfoCompletedHandler(object sender,GetUserUidCompletedEventArgs  e)
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
                UserDetails user = new UserDetails();
                user = e.Result;
                ObservableCollection<UserDetails> User_List = new ObservableCollection<UserDetails>() { user };

                UserList_Box.ItemsSource = User_List;
            }
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }
    }
}