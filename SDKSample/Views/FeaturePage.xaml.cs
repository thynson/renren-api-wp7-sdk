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
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Resources;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public partial class FeaturePage : PhoneApplicationPage
    {
        RenrenAPI api = App.api;
        public FeaturePage()
        {
            InitializeComponent();

            DataContext = (object)App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }


        private void OneTapPublishListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(OneTapPublishListBox.SelectedIndex != -1)
            {
                switch (OneTapPublishListBox.SelectedIndex)
                 {
                case 0://一键上传照片
                    {
                        StreamResourceInfo info = Application.GetResourceStream(new Uri("Background.png", UriKind.Relative));
                        BitmapImage bmp = new BitmapImage();
                        bmp.SetSource(info.Stream);
                        App.api.PublishPhotoSimple(bmp, "Background.png", "照片描述");                                              
                    } 
                    break;
                case 1://一键发布状态
                    break;
                 }
            }
            OneTapPublishListBox.SelectedIndex = -1;
        }

        private void PublishListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PublishListBox.SelectedIndex != -1)
            {
                switch (PublishListBox.SelectedIndex)
                {
                    case 0://上传照片
                        NavigationService.Navigate(new Uri("/Views/UploadPhoto.xaml", UriKind.RelativeOrAbsolute));
                        break; 
                    case 1://发布状态
                        break;
                    case 2://发布自定义新鲜事
                        break;
                }
            }
            PublishListBox.SelectedIndex = -1;
        }

        private void AlbumListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AlbumListBox.SelectedIndex != -1)
            {
                switch (AlbumListBox.SelectedIndex)
                {
                    case 0://相册列表    
                        {
                            App.api.GetAlbums(GetAlbumsCompletedCallback);
                        }
                        break;

                    case 1://新建相册
                        NavigationService.Navigate(new Uri("/Views/newAlbum.xaml", UriKind.Relative));
                        break;
                }
                AlbumListBox.SelectedIndex = -1;
            }
        }

        private void FriendListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FriendListBox.SelectedIndex != -1)
            {
                switch (FriendListBox.SelectedIndex)
                {
                    case 0://好友ID列表
                        NavigationService.Navigate(new Uri("/Views/FriendsIDList.xaml", UriKind.RelativeOrAbsolute));
                        break;

                    case 1://好友列表
                        NavigationService.Navigate(new Uri("/Views/FriendsList.xaml", UriKind.RelativeOrAbsolute));
                        break;
                    case 2://应用好友列表
                        NavigationService.Navigate(new Uri("/Views/AppFriendsListPage.xaml", UriKind.RelativeOrAbsolute));
                        break;
                }
            }
            FriendListBox.SelectedIndex = -1;
        }

        private void UserListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserListBox.SelectedIndex != -1)
            {
                switch (UserListBox.SelectedIndex)
                {
                    case 0://当前用户信息
                        NavigationService.Navigate(new Uri("/Views/CurUserInfoPage.xaml", UriKind.RelativeOrAbsolute));
                        break;

                    case 1://指定用户信息
                        NavigationService.Navigate(new Uri("/Views/UserInfoPage.xaml", UriKind.RelativeOrAbsolute));
                        break;
                }
            }
            UserListBox.SelectedIndex = -1;
        }

        private void DialogListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DialogListBox.SelectedIndex != -1)
            {
                switch (DialogListBox.SelectedIndex)
                {
                    case 0:
                        {
                            NewfeedDialogRequired paramRequired = new NewfeedDialogRequired();
                            NewfeedDialogOptional paramOptional = new NewfeedDialogOptional();
                            paramRequired.app_id = "156729";
                            paramRequired.description = "我的测试";
                            paramRequired.name = "创建新鲜事";
                            paramRequired.redirect_uri = "http://apps.renren.com/demo_app";
                            paramRequired.url = "http://apps.renren.com/demo_app";

                            paramOptional.action_link = "http://apps.renren.com/demo_app";
                            paramOptional.action_name = "";
                            paramOptional.caption = "自定义";
                            paramOptional.image = "http://xnimg.connect.renren.com/app_full_proxy.do?src=http://pic.yupoo.com/dapenti/AFtF7sVF/Dp6WT.jpg";

                            api.FeedDialog(this, paramRequired, paramOptional, NewfeedDialogComplete);
                        }
                        break;

                    case 1:
                        api.LikeDialog(this, "http://app.renren.com/", "156729", NewfeedDialogComplete);
                        break;

                    case 2:
                        //NavigationService.Navigate(new Uri("/LogPage.xaml", UriKind.Relative));
                        break;

                    case 3:
                        {                            
                            break;
                        }
                    case 4:
                        //NavigationService.Navigate(new Uri("/LogPage.xaml", UriKind.Relative));
                        break;
                }
            }
            DialogListBox.SelectedIndex = -1;
        }
        //得到相册数据的回调
        private void GetAlbumsCompletedCallback(object sender, GetAlbumsCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result as List<Album> != null)
                {
                    ObservableCollection<Album> albumslist = new ObservableCollection<Album>();
                    foreach (var item in e.Result)
                    {                        
                        albumslist.Add(item);
                    }

                    AlbumsList.ItemsSource = albumslist;
                }
            }
            else
                MessageBox.Show(e.Error.Message);
        }

        void NewfeedDialogComplete(object sender, RenrenSDKLibrary.DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else
                MessageBox.Show(e.Result);
        }
    }
}