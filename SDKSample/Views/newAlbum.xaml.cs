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
    public partial class newAlbum : PhoneApplicationPage
    {
        public newAlbum()
        {
            InitializeComponent();
        }

        private void Upload_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (tb_name.Text == "")
                MessageBox.Show("请输入相册名称");
            else
            {
                App.api.CreateAlbum(CreateAlbumCompletedCallback, tb_name.Text);
            }
        }
        //显示新相册aid
        private void CreateAlbumCompletedCallback(object sender, CreateAlbumCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("创建成功");
                tb_result.Text = "aid: " + e.Result.aid.ToString();
            }
            else
                MessageBox.Show(e.Error.Message);
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }
    }
}