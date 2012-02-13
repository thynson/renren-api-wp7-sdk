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

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("prepage") 
                && ((NavigationContext.QueryString["prepage"] == "webcontrolpage")
                || (NavigationContext.QueryString["prepage"] == "passwordpage")))
            {
                NavigationService.RemoveBackEntry();
            }
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

        private void LogOut_Btn_Clicked(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                api.LogOut();
                NavigationService.GoBack();
            }
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
                            List<APIParameter> param= new List<APIParameter>();
                            param.Add(new APIParameter("url","http://dev.renren.com"));
                            param.Add(new APIParameter("name", "人人网开放平台"));
                            param.Add(new APIParameter("action_name","访问我们"));
                            param.Add(new APIParameter("action_link","http://dev.renren.com"));
                            param.Add(new APIParameter("description","来自人人网Windows Phone 7 SDK"));
                            param.Add(new APIParameter("caption","欢迎使用人人网SDK"));
                            param.Add(new APIParameter("image","http://hdn.xnimg.cn/photos/hdn421/20090923/1935/head_1Wmz_19242g019116.jpg"));

                            api.WidgetDialog(this, WidgetDialogType.FeedDialog, param, WidgetDialogComplete);
                        }
                        break;

                    case 1:
                        {
                            List<APIParameter> param = new List<APIParameter>();
                            param.Add(new APIParameter("like_url","http://hecao.info/like.html"));

                            api.WidgetDialog(this,WidgetDialogType.LikeDialog,param,WidgetDialogComplete);
                        }
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

        private void RestAPIListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RestAPIListBox.SelectedIndex != -1)
            {
                switch (RestAPIListBox.SelectedIndex)
                {
                    case 0://发表日志
                        NavigationService.Navigate(new Uri("/Views/RestAPIPage.xaml", UriKind.RelativeOrAbsolute));
                        break;
                }
            }
            RestAPIListBox.SelectedIndex = -1;
        }

        void WidgetDialogComplete(object sender, RenrenSDKLibrary.DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else
                MessageBox.Show(e.Result);
        }
    }
}