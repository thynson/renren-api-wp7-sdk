//  Copyright 2011年 Renren Inc. All rights reserved.
//  - Powered by Team Pegasus. -

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using RenrenSDKLibrary.Constants;
using Microsoft.Phone.Controls;
using System.IO;
using System.Windows.Media.Imaging;

namespace RenrenSDKLibrary
{
    public class RenrenAPI
    {
        RenrenSDK rrSDK;

        // Constructor
        public RenrenAPI( string apiKey )
        {
            rrSDK = new RenrenSDK(apiKey);
        }

        /// <summary>
        /// 清空用户信息
        /// </summary>
        public void LogOut()
        {
            rrSDK.LogOut();
        }
        
        /// <summary>
        /// 用户名密码方式，无权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="secretKey">应用程序secretkey</param>
        /// <param name="callback">回调</param>
        public void Login(string username, string password, string secretKey,
            LoginCompletedHandler callback)
        {
            rrSDK.LogIn(username, password, secretKey, callback);
        }

        /// <summary>
        /// 用户名密码方式，有权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="secretKey">应用程序secretkey</param>
        /// <param name="scope">权限列表</param>
        /// <param name="callback">回调</param>
        public void Login(string username, string password, string secretKey,
            List<string> scope, LoginCompletedHandler callback)
        {
            rrSDK.LogIn(username, password, secretKey, scope, callback);
        }

        /// <summary>
        /// 登录，页面方式，无权限设置
        /// </summary>
        /// <param name="page">当前显示页面</param>
        public void Login(PhoneApplicationPage page, LoginCompletedHandler callback)
        {
            rrSDK.LogIn(page, ConstantValue.Redirect_Uri, callback);
        }

        /// <summary>
        /// 登录，页面方式，有权限设置
        /// </summary>
        /// <param name="page">当前显示页面</param>
        /// <param name="scope">权限列表</param>
        /// <param name="redirectUri">转向</param>
        public void Login(PhoneApplicationPage page, List<string> scope,
            LoginCompletedHandler callback)
        {
            rrSDK.LogIn(page, scope, ConstantValue.Redirect_Uri, callback);
        }

        /// <summary>
        /// 获取好友id列表，带分页参数 page和count
        /// </summary>
        /// <param name="callback">回调，返回 ObservableCollection<int> </param>
        /// <param name="count">返回每页个数,默认为500</param>
        /// <param name="page">分页，默认为1</param>
        public void GetFriendsID( GetFriendsIDCompletedHandler callback, int count=500,int page=1)
        {
            rrSDK.GetFriendsID(callback, count, page);
        }

        /// <summary>
        /// 得到当前登录用户的好友列表，带额外scope参数列表
        /// </summary>
        /// <param name="callback">回调</param>
        /// <param name="scope">需要返回的字段，目前支持如下字段: headurl_with_logo, tinyurl_with_logo</param>
        /// <param name="count">返回每页个数，默认为500</param>
        /// <param name="page">分页，默认为1</param>
        public void GetFriends(GetFriendsCompletedHandler callback,  List<string> scope, int count=500, int page=1 )
        {
            rrSDK.GetFriends(callback, scope, count, page);
        }

        /// <summary>
        /// 得到当前登录用户的好友列表，不带额外scope参数列表
        /// </summary>
        /// <param name="callback">回调</param>
        /// <param name="scope">需要返回的字段，目前支持如下字段: headurl_with_logo, tinyurl_with_logo</param>
        /// <param name="count">返回每页个数，默认为500</param>
        /// <param name="page">分页，默认为1</param>
         public void GetFriends(GetFriendsCompletedHandler callback, int count=500, int page=1 )
        {
            rrSDK.GetFriends(callback, count, page );
        }

        /// <summary>
        /// 获取App好友列表，带Scope参数列表
        /// </summary>
        /// <param name="sessionkey">当前用户的session_key</param>
        /// <param name="userid">当前用户的id</param>
        /// <param name="scope">目前支持name（姓名）、tinyurl(小头像)、headurl（中等头像）</param>
        /// <param name="callback">回调，返回 ObservableCollection<AppFriend> </param>
        public void GetAppFriends(List<string> scope, GetAppFriendsCompletedHandler callback)
        {
            rrSDK.GetAppFriends(scope, callback);
        }

        /// <summary>
        /// 获取App好友列表，不带Scope参数列表
        /// </summary>
        /// <param name="sessionkey">当前用户的session_key</param>
        /// <param name="userid">当前用户的id</param>
        /// <param name="callback">回调，返回 ObservableCollection<AppFriend> </param>
        public void GetAppFriends(GetAppFriendsIDCompletedHandler callback)
        {
            rrSDK.GetAppFriends(callback);
        }

        /// <summary>
        /// 创建相册
        /// </summary> 
        /// <param name="callback">回调</param>
        /// <param name="name">相册名称</param>
        /// <param name="caption">相册描述(可选)</param>
        /// <param name="location">位置(可选)</param>

        public void CreateAlbum(CreateAlbumRequest.CreateAlbumCompletedHandler callback, string name, string description=null, string location=null)
        {
            rrSDK.CreateAlbum(name, description, location, callback);
        }

        /// <summary>
        /// 获取当前用户相册列表
        /// </summary>   
        /// <param name="callback">回调</param>
        /// <param name="page">分页（可选）</param>
        /// <param name="count">每页个数（可选）</param>
        /// <param name="aids">相册id，用逗号隔开，最多十个（可选）</param>
        public void GetAlbums(RenrenSDKLibrary.GetAlbumsRequest.GetAlbumsCompletedHandler callback, 
            int page = -1, int count = -1, string aids = null)
        {
            rrSDK.GetAlbums(callback,page,count,aids);
        }
		
        /// <summary>
        /// 一键上传照片接口
        /// </summary> 
        /// <param name="imgPath">照片路径</param>
        /// <param name="caption">照片描述</param>
        public void PublishPhotoSimple(BitmapImage photo, string imgPath, string caption)
        {
            rrSDK.FastUploadPhoto(photo, imgPath, caption);          
        }
		
       /// <summary>
       /// 上传照片接口
       /// </summary>
       /// <param name="photo">照片</param>
       /// <param name="name">照片名称，包含后缀</param>
       /// <param name="callback">回调void UploadPhotoCompletedHandler(object sender, UploadPhotoCompletedEventArgs e)</param>
       /// <param name="caption">描述</param>
       /// <param name="albumId">相册id</param>
        public void PublishPhoto(BitmapImage photo, string name, UploadPhotoCompletedHandler callback,
             string caption = null, int albumId = 0)
        {
            rrSDK.UploadPhoto(photo, name, callback, caption, albumId);
        }

        /// <summary>
        /// 上传照片接口
        /// </summary>
        /// <param name="fileName">文件全路径</param>
        /// <param name="fileName">回调void UploadPhotoCompletedHandler(object sender, UploadPhotoCompletedEventArgs e)</param>
        /// <param name="caption">描述</param>
        /// <param name="albumId">相册id</param>
        public void PublishPhoto(string fileName, UploadPhotoCompletedHandler callback,
             string caption = null, int albumId = 0)
        {
            rrSDK.UploadPhoto(fileName, callback, caption, albumId);
        }

        /// <summary>
        /// 获取log信息
        /// </summary>
        /// <returns></returns>
        public string ReadLog()
        {
            return rrSDK.ReadLog();
        }

        /// <summary>
        /// 清空log信息
        /// </summary>
        public void Cleanlog()
        {
            rrSDK.Cleanlog();
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <param name="callback">回调</param>
        public void GetCurUserInfo(GetCurUserInfoCompletedHandler callback)
        {
            rrSDK.GetCurUserInfo(callback);
        }

        /// <summary>
        /// 获取指定用户信息，可以支持一次查询多个用户信息
        /// </summary>
        /// <param name="uid">用户uid，多个用户用“，”隔开</param>
        /// <param name="scope">需要查询的字段</param>
        /// <param name="callback">回调</param>
        public void GetUserInfo(string uid, List<string> scope, GetUserInfoCompletedHandler callback)
        {
            rrSDK.GetUserInfo(uid, scope, callback);
        }

        /// <summary>
        /// 可以发送自定义新鲜事的widget
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="requiredParam">必须的参数</param>
        /// <param name="optionalParam">可选的参数</param>
        /// <param name="callback">回调</param>
        public void FeedDialog(PhoneApplicationPage page, NewfeedDialogRequired requiredParam,
            NewfeedDialogOptional optionalParam = null,
            RenrenSDKLibrary.WidgetDialog.NewfeedWidgetDialog.DownloadStringCompletedHandler callback = null)
        {
            rrSDK.NewFeedWidgetDialog(page, requiredParam, optionalParam,callback);
        }

        /// <summary>
        /// like dialog提供了人人喜欢另一种实现，使人人喜欢可以应用在多种终端。 
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="like_url">被喜欢页面的url</param>
        /// <param name="callback">回调</param>
        public void LikeDialog(PhoneApplicationPage page, string like_url, string app_id,
            RenrenSDKLibrary.WidgetDialog.LikeWidgetDialog.DownloadStringCompletedHandler callback = null)
        {
            rrSDK.LikeWidgetDialog(page, like_url, app_id, callback);
        }
    }
}
