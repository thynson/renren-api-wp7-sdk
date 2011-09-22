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
using System.IO.IsolatedStorage;
using System.IO;

namespace RenrenSDKLibrary
{
    internal class RenrenAppInfo
    {
        #region Members
        public RenrenUserInfo userInfo = null;
        public UserDetails detailInfo = null;
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        string userInfoKey = "RenrenUserInfo";
        string detailInfoKey = "RenrenDetailInfo";
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public RenrenAppInfo()
        { 
            if(!settings.TryGetValue<RenrenUserInfo>(userInfoKey, out userInfo))
                userInfo = new RenrenUserInfo();
            if(!settings.TryGetValue<UserDetails>(detailInfoKey, out detailInfo))
                detailInfo = new UserDetails();
        }

        #region PublicFunction
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="info">信息</param>
        public void SetUserInfo(UserInfo info)
        {
            if (info == null)
                return;
            userInfo.SetUserInfo(info);
            if (!settings.Contains(userInfoKey))
            {
                settings.Add(userInfoKey, userInfo);
            }
            else
            {
                settings[userInfoKey] = userInfo;
            }
        }

        /// <summary>
        /// 设置详细信息
        /// </summary>
        /// <param name="info">信息</param>
        public void SetDetailInfo(UserDetails info)
        {
            if (info == null)
                return;
            detailInfo = info;
            if (!settings.Contains(detailInfoKey))
            {
                settings.Add(detailInfoKey, detailInfo);
            }
            else
            {
                settings[detailInfoKey] = detailInfo;
            }
        }

        /// <summary>
        /// 清除信息
        /// </summary>
        public void CleanUp()
        {
            userInfo = null;
            detailInfo = null;
        }
        #endregion
    }

    public class RenrenUserInfo
    {
        /// <summary>
        /// 构造 
        /// </summary>
        public RenrenUserInfo()
        {
            //using (IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    StreamReader readFile = null;
            //    try
            //    {
            //        readFile = new StreamReader(new IsolatedStorageFileStream("RenrenUserInfo\\\\userInfo",
            //            FileMode.Open, myStore));
            //        access_token = readFile.ReadLine();
            //        refresh_token = readFile.ReadLine();
            //        oauth_token = readFile.ReadLine();
            //        session_secret = readFile.ReadLine();
            //        expires_in = readFile.ReadLine();
            //        session_key = readFile.ReadLine();
            //        string idstr = readFile.ReadLine();
            //        id = int.Parse(idstr);
            //        scope = readFile.ReadLine();
            //        readFile.Close();
            //    }
            //    catch
            //    {
            //        return;
            //    }
            //}
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="info">用户信息</param>
        public void SetUserInfo(UserInfo info)
        {
            access_token = info.user_Token.access_token;
            refresh_token = info.user_Token.refresh_token;
            oauth_token = info.user_Session.oauth_token;
            session_secret = info.user_Session.renren_token.session_secret;
            expires_in = info.user_Session.renren_token.expires_in;
            session_key = info.user_Session.renren_token.session_key;
            id = info.user_Session.user.id;
            scope = info.user_Token.scope;

            //using (IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    if (!myStore.DirectoryExists("RenrenUserInfo"))
            //    {
            //        myStore.CreateDirectory("RenrenUserInfo");
            //    }
            //    StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("RenrenUserInfo\\\\userInfo",
            //        FileMode.OpenOrCreate, myStore));
            //    writeFile.WriteLine(access_token);
            //    writeFile.WriteLine(refresh_token);
            //    writeFile.WriteLine(oauth_token);
            //    writeFile.WriteLine(session_secret);
            //    writeFile.WriteLine(expires_in);
            //    writeFile.WriteLine(session_key);
            //    writeFile.WriteLine(id);
            //    writeFile.WriteLine(scope);
            //    writeFile.Close();
            //}
        }

        public void CleanUp()
        {
            access_token = null;
            refresh_token = null;
            oauth_token = null;
            session_secret = null;
            expires_in = null;
            session_key = null;
            id = 0;
            scope = null;
        }

        public string oauth_token { get; set; }

        public string access_token { get; set; }

        public string refresh_token { get; set; }

        public string session_secret { get; set; }

        public string expires_in { get; set; }

        public string session_key { get; set; }

        public string scope { get; set; }

        public int id { get; set; }
    }


    public class UserInfo
    {
        public Sessioninfo user_Session { get; set; }

        public TokenInfo user_Token { get; set; }
    }

    public class TokenInfo
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string refresh_token { get; set; }

        public string scope { get; set; }
    }

    public class Sessioninfo
    {
        public Token renren_token { get; set; }

        public string oauth_token { get; set; }

        public User user { get; set; }
    }

    public class Token
    {
        public string session_secret { get; set; }

        public string expires_in { get; set; }

        public string session_key { get; set; } 
    }

    public class User
    {
        public int id { get; set; }
    }
}
