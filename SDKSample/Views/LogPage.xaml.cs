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
    public partial class LogPage : PhoneApplicationPage
    {
        RenrenAPI api = App.api;
        public LogPage()
        {
            InitializeComponent();
            Result_TBlk.Text = api.ReadLog();
        }

        private void Clean_Btn_Click(object sender, RoutedEventArgs e)
        {
            api.Cleanlog();
            Result_TBlk.Text = "";
        }
    }
}