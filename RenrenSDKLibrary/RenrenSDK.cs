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
using RenrenSDKLibrary;
using RenrenSDKLibrary.Constants;
using Microsoft.Phone.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using RenrenSDKLibrary.WidgetDialog;


namespace RenrenSDKLibrary
{
    internal class RenrenSDK
    {
        public static RenrenAppInfo RenrenInfo = new RenrenAppInfo();
        LoginBS loginBS;
        FriendBS friendBS;
        LoginViewBS loginViewBS;
        UploadPhotoBS uploadBS;
        GetUserInfoBS getUserInfoBS;
        GetAlbumsBS getAlbumsBS;
        CreateAlbumBS createAlbumBS;
        NewfeedWidgetDialog newfeedDialog;
        LikeWidgetDialog LikeDialog;
        public static BitmapImage publishPhoto;//通过api传进来的照片

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="apiKey"></param>
        public RenrenSDK(string apiKey)
        {
            ConstantValue.ApiKey = apiKey;            
            friendBS = new FriendBS();
            getUserInfoBS = new GetUserInfoBS();
        }

        /// <summary>
        /// 清空信息
        /// </summary>
        public void LogOut()
        {
            loginBS = null;
            friendBS = null;
            loginViewBS = null;
            uploadBS = null;
            getUserInfoBS = null;
            getAlbumsBS = null;
            createAlbumBS = null;
            RenrenInfo.CleanUp();
            newfeedDialog = null;
            LikeDialog = null;
        }

        /// <summary>
        /// 用户名密码方式，无权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="secretKey">应用程序secretkey</param>
        /// <param name="callback">回调</param>
        public void LogIn(string username, string password, string secretKey,
            LoginCompletedHandler callback)
        {
             LogIn(username, password, secretKey,null, callback);
        }

        /// <summary>
        /// 用户名密码方式，有权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="secretKey">应用程序secretkey</param>
        /// <param name="scope">权限列表</param>
        /// <param name="callback">回调</param>
        public void LogIn(string username, string password, string secretKey,
            List<string> scope, LoginCompletedHandler callback)
        {
            ConstantValue.SecretKey = secretKey;
            if (loginBS == null)
            {
                loginBS = new LoginBS();
            }
            loginBS.CleanLoginEvent();
            loginBS.LoginCompleted += callback; 

            loginBS.LogIn(username, password, scope);
        }

        /// <summary>
        /// 登录，页面方式，无权限设置
        /// </summary>
        /// <param name="page">当前显示页面</param>
        /// <param name="redirectUri">转向</param>
        public void LogIn(PhoneApplicationPage page, string redirectUri,
            LoginCompletedHandler callback)
        {
            LogIn(page, null, redirectUri, callback);
        }

        /// <summary>
        /// 登录，页面方式，有权限设置
        /// </summary>
        /// <param name="page">当前显示页面</param>
        /// <param name="scope">权限列表</param>
        /// <param name="redirectUri">转向</param>
        public void LogIn(PhoneApplicationPage page, List<string> scope,
            string redirectUri, LoginCompletedHandler callback)
        {
            if (loginViewBS == null)
            {
                loginViewBS = new LoginViewBS();
            }

            loginViewBS.CleanLoginEvent();
            loginViewBS.LoginCompleted += callback; 

            loginViewBS.InitView(page);
            loginViewBS.Login(redirectUri, scope);
        }

        /// <summary>
        /// 获取好友id列表
        /// </summary>
        /// <param name="callback">回调</param>
        /// <param name="count">返回每页个数,默认为500</param>
        /// <param name="page">分页，默认为1</param>
        public void GetFriendsID( GetFriendsIDCompletedHandler callback , int count =500 , int page =1)
        {
            if (friendBS == null)
            {
                friendBS = new FriendBS();
            }
            friendBS.CleanGetFriendsIDEvent();
            friendBS.GetFriendsIDCompleted += callback;
            friendBS.GetFriendsID( count, page);
        }

         /// <summary>
         /// 得到当前登录用户的好友列表，带scope参数
         /// </summary>
         /// <param name="callback">回调</param>
         /// <param name="scope">需要返回的字段，目前支持如下字段: headurl_with_logo, tinyurl_with_logo</param>
         /// <param name="count">返回每页个数，默认为500</param>
         /// <param name="page">分页，默认为1</param>
         public void GetFriends(GetFriendsCompletedHandler callback ,List<string> scope ,int count = 500, int page = 1)
         {
             if (friendBS == null)
             {
                 friendBS = new FriendBS();
             }
             friendBS.CleanGetFriendsEvent();
             friendBS.GetFriendsCompleted += callback;
             friendBS.GetFriends(scope, count, page);
         }

        /// <summary>
         /// 得到当前登录用户的好友列表，不带scope参数
         /// </summary>
         /// <param name="callback">回调</param>
         /// <param name="count">返回每页个数，默认为500</param>
         /// <param name="page">分页，默认为1</param>
         public void GetFriends(GetFriendsCompletedHandler callback, int count = 500, int page = 1)
         {
             if (friendBS == null)
             {
                 friendBS = new FriendBS();
             }
             friendBS.CleanGetFriendsEvent();
             friendBS.GetFriendsCompleted += callback;
             friendBS.GetFriends( null, count, page);
         }


         /// <summary>
         /// 获取好友App列表，带Scope参数
         /// </summary>
         /// <param name="sessionkey">当前用户的session_key</param>
         /// <param name="userid">当前用户的id</param>
         /// <param name="scope">参数列表</param>
         /// <param name="callback">回调</param>
         public void GetAppFriends( List<string> scope, GetAppFriendsCompletedHandler callback)
         {
             if (friendBS == null)
             {
                 friendBS = new FriendBS();
             }
             friendBS.CleanGetAppFriendsEvent();
             friendBS.GetAppFriendsCompleted += callback;
             friendBS.GetAppFriends(scope);
         }

         /// <summary>
         /// 获取App好友列表，不带Scope参数
         /// </summary>
         /// <param name="sessionkey">当前用户的session_key</param>
         /// <param name="userid">当前用户的id</param>
         /// <param name="callback">回调</param>
         public void GetAppFriends( GetAppFriendsIDCompletedHandler callback)
         {
             if (friendBS == null)
             {
                 friendBS = new FriendBS();
             }
             friendBS.CleanGetAppFriendsIDEvent();
             friendBS.GetAppFriendsIDCompleted += callback;
             friendBS.GetAppFriends(null);
         }

         /// <summary>
         /// 获取当前用户相册列表
         /// </summary>
         public void GetAlbums(RenrenSDKLibrary.GetAlbumsRequest.GetAlbumsCompletedHandler callback, int page, int count, string aids)
         {
             if (getAlbumsBS == null)
             {
                 getAlbumsBS = new GetAlbumsBS();
             }

             getAlbumsBS.CleanGetAlbumsEvent();
             getAlbumsBS.GetAlbumsCompleted += callback;
             getAlbumsBS.GetAlbums(RenrenInfo.userInfo.session_key, RenrenInfo.userInfo.session_secret,
                    RenrenInfo.userInfo.id, page, count, aids);
         }

         /// <summary>
         /// 创建相册
         /// </summary>
         public void CreateAlbum(string name, string description,string location, CreateAlbumRequest.CreateAlbumCompletedHandler callback)
         {
             if (createAlbumBS == null)
             {
                 createAlbumBS = new CreateAlbumBS();
             }
             createAlbumBS.CleanCreatAlbumEvent();
             createAlbumBS.CreateAlbumCompleted += callback;
             createAlbumBS.CreateAlbum(RenrenInfo.userInfo.session_key, 
                    RenrenInfo.userInfo.session_secret, name, description, location);
         }
         /// <summary>
         /// 照片一键上传
         /// </summary>
         internal void FastUploadPhoto(BitmapImage photo,string imgPath, string caption)
         {
             publishPhoto = photo;
             (Application.Current.RootVisual as PhoneApplicationFrame).
                 Navigate(new Uri("/RenrenSDKLibrary;component/Pages/UploadPhotoPage.xaml?path=" + imgPath + "&caption=" + caption, 
                          UriKind.Relative)); 
         }

        /// <summary>
        /// 上传照片接口
        /// </summary>
        /// <param name="photo">照片</param>
        /// <param name="caption">描述</param>
        /// <param name="callback">回调</param>
         public void UploadPhoto(BitmapImage photo, string name, UploadPhotoCompletedHandler callback,
             string caption, int albumId)
        {
            if (uploadBS == null)
            {
                uploadBS = new UploadPhotoBS();
            }
            uploadBS.CleanUploadPhotoEvent();
            uploadBS.UploadCompleted += callback;
            uploadBS.UploadPhoto(photo, name, caption, albumId);
        }

         /// <summary>
         /// 上传照片接口
         /// </summary>
         /// <param name="fileName">文件全路径</param>
         /// <param name="caption">描述</param>
         /// <param name="albumId">回调</param>
         public void UploadPhoto(string fileName,UploadPhotoCompletedHandler callback,
             string caption, int albumId)
         {
             if (uploadBS == null)
             {
                 uploadBS = new UploadPhotoBS();
             }
             uploadBS.CleanUploadPhotoEvent();
             uploadBS.UploadCompleted += callback;
             uploadBS.UploadPhoto(fileName, caption, albumId);
         }

         /// <summary>
         /// 获取log信息
         /// </summary>
         /// <returns></returns>
         public string ReadLog()
         {
             return ApiHelper.ReadLog();
         }

         /// <summary>
         /// 清空log信息
         /// </summary>
        public void Cleanlog()
        {
             ApiHelper.CleanLog();
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <param name="sessionkey">当前用户的session_key</param>
        /// <param name="callback">回调</param>
        public void GetCurUserInfo(GetCurUserInfoCompletedHandler callback)
        {
            if (getUserInfoBS == null)
            {
                getUserInfoBS = new GetUserInfoBS();

            }
            getUserInfoBS.ClearGetCurUserInfoEvent();
            getUserInfoBS.GetCurUserInfoCompleted += callback;
            getUserInfoBS.GetCurUserID();
        }

        /// <summary>
        /// 获取指定用户信息
        /// </summary>
        /// <param name="sessionkey">指定用户的uid，可以是多个uid中间用逗号隔开</param>
        /// <param name="callback">回调</param>
        public void GetUserInfo(string uid, List<string> scope, GetUserInfoCompletedHandler callback)
        {
            if (getUserInfoBS == null)
            {
                getUserInfoBS = new GetUserInfoBS();

            }
            getUserInfoBS.ClearGetUserInfoEvent();
            getUserInfoBS.GetUserInfoCompleted += callback;
            getUserInfoBS.GetUsersID(uid, scope);
        }

        /// <summary>
        /// 可以发送自定义新鲜事的widget
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="requiredParam">必须的参数</param>
        /// <param name="optionalParam">可选的参数</param>
        /// <param name="callback">回调</param>
        public void NewFeedWidgetDialog(PhoneApplicationPage page, NewfeedDialogRequired requiredParam,
            NewfeedDialogOptional optionalParam, 
            RenrenSDKLibrary.WidgetDialog.NewfeedWidgetDialog.DownloadStringCompletedHandler callback)
        {
            if (newfeedDialog == null)
            {
                newfeedDialog = new NewfeedWidgetDialog();
            }

            if (callback != null)
            {
                newfeedDialog.CleanDownloadStringEvent();
                newfeedDialog.DownloadStringCompleted += callback;
            }

            newfeedDialog.InitView(page);
            newfeedDialog.RunDialog(requiredParam, optionalParam);
        }

        /// <summary>
        /// like dialog提供了人人喜欢另一种实现，使人人喜欢可以应用在多种终端。 
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="like_url">被喜欢页面的url</param>
        /// <param name="callback">回调</param>
        public void LikeWidgetDialog(PhoneApplicationPage page, string like_url, string app_id,
            RenrenSDKLibrary.WidgetDialog.LikeWidgetDialog.DownloadStringCompletedHandler callback)
        {
            if (LikeDialog == null)
            {
                LikeDialog = new LikeWidgetDialog();
            }

            if (callback != null)
            {
                LikeDialog.CleanDownloadStringEvent();
                LikeDialog.DownloadStringCompleted += callback;
            }

            LikeDialog.InitView(page);
            LikeDialog.RunDialog(like_url, app_id);
        }
    }
}


