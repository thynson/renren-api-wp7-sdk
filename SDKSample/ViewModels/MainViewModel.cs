//  Copyright 2011年 Renren Inc. All rights reserved.
//  - Powered by Team Pegasus. -

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace SDKSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.UserInfo = new ObservableCollection<ItemViewModel>();
            this.FriendInfo = new ObservableCollection<ItemViewModel>();
            this.AlbumInfo = new ObservableCollection<ItemViewModel>();
            this.DialogInfo = new ObservableCollection<ItemViewModel>();
            this.PublishInfo = new ObservableCollection<ItemViewModel>();
            this.OneTapPubllish = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> UserInfo { get; private set; }
        public ObservableCollection<ItemViewModel> FriendInfo { get; private set; }
        public ObservableCollection<ItemViewModel> AlbumInfo { get; private set; }
        public ObservableCollection<ItemViewModel> PublishInfo { get; private set; }
        public ObservableCollection<ItemViewModel> OneTapPubllish { get; private set; }
        public ObservableCollection<ItemViewModel> DialogInfo { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.UserInfo.Add(new ItemViewModel() { LineOne = "当前用户信息", LineTwo = "GetCurUserInfo" });
            this.UserInfo.Add(new ItemViewModel() { LineOne = "指定用户信息", LineTwo = "GetUserInfo" });

            this.FriendInfo.Add(new ItemViewModel() { LineOne = "好友id列表", LineTwo = "GetFriendsID" });
            this.FriendInfo.Add(new ItemViewModel() { LineOne = "好友列表", LineTwo = "GetFriends" });
            this.FriendInfo.Add(new ItemViewModel() { LineOne = "应用好友列表", LineTwo = "GetAppFriends" });

            this.AlbumInfo.Add(new ItemViewModel() { LineOne = "相册列表", LineTwo = "GetAlbums" });
            this.AlbumInfo.Add(new ItemViewModel() { LineOne = "新建相册", LineTwo = "CreateAlbum" });

            //this.OneTapPubllish.Add(new ItemViewModel() { LineOne = "一键发布状态",  LineTwo = ""});
            this.OneTapPubllish.Add(new ItemViewModel() { LineOne = "一键上传照片", LineTwo = "PublishPhotoSimple" });

            //this.PublishInfo.Add(new ItemViewModel() { LineOne = "发布状态*", LineTwo = "" });
            //this.PublishInfo.Add(new ItemViewModel() { LineOne = "发布自定义新鲜事*", LineTwo = "" });
            this.PublishInfo.Add(new ItemViewModel() { LineOne = "上传照片", LineTwo = "PublishPhoto" });


            this.DialogInfo.Add(new ItemViewModel() { LineOne = "Feed Dialog", LineTwo = "FeedDialog" });
            //this.DialogInfo.Add(new ItemViewModel() { LineOne = "Request Dialog*", LineTwo = "Nascetur phaar" });
            //this.DialogInfo.Add(new ItemViewModel() { LineOne = "Status Dialog*", LineTwo = "Maecenas pendum" });
            this.DialogInfo.Add(new ItemViewModel() { LineOne = "like Dialog", LineTwo = "LikeDialog" });
            //this.DialogInfo.Add(new ItemViewModel() { LineOne = "Friends Dialog*", LineTwo = "Habitant incertis" });


            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}