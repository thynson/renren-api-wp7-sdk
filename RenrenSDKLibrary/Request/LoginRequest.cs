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
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.Phone.Info;
using RenrenSDKLibrary.Constants;

namespace RenrenSDKLibrary
{
    public delegate void LoginCompletedHandler(object sender, LoginCompletedEventArgs e);

    public class LoginRequest: RenrenClient
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public void LogIn(string username, string password, List<string> scope, 
            DownloadStringCompletedHandler callback )
        {
            List<APIParameter> parameters = new List<APIParameter>() { 
                new APIParameter("method","admin.getAllocation")
            };
            parameters.Add(new APIParameter("grant_type", "password"));
            parameters.Add(new APIParameter("username", username));
            parameters.Add(new APIParameter("password", password));
            parameters.Add(new APIParameter("client_id", ConstantValue.ApiKey));
            parameters.Add(new APIParameter("client_secret", ConstantValue.SecretKey));

            if (scope != null && scope.Count > 0)
            {
                string[] arrScope = scope.ToArray<string>();
                parameters.Add(new APIParameter("scope", String.Join(" ", arrScope)));
            }

            RenrenWebRequest logInAgent = new RenrenWebRequest();
            logInAgent.DownloadStringCompleted +=
                new RenrenWebRequest.DownloadStringCompletedHandler(callback);

            logInAgent.DownloadStringAsync(ConstantValue.OAuthUri.ToString(), parameters);           
        }

        /// <summary>
        /// 获得Session_key
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="callback"></param>
        public void GetSessionKey(string accessToken, DownloadStringCompletedHandler callback)
        {
            if (accessToken == "")
                return;
            List<APIParameter> paras = new List<APIParameter>() { 
                new APIParameter("oauth_token",accessToken)
            };
            RenrenWebRequest client = new RenrenWebRequest();
            client.DownloadStringCompleted +=
                new RenrenWebRequest.DownloadStringCompletedHandler(callback);

            client.DownloadStringAsync(ConstantValue.SessionURL, paras);
        }


        /// <summary>
        /// 获取Access Token,
        /// 通过第一步返回的URL获得参数Code的值，就为Authorization Code
        /// </summary>
        /// <returns></returns>
        public void GetAccessToken(string authorizationCode,string redirectUri,
            DownloadStringCompletedHandler callback)
        {
            if (authorizationCode == "") throw new ArgumentNullException("authorization code required.");
            List<APIParameter> paras = new List<APIParameter>() { 
                    new APIParameter("grant_type","authorization_code"),
                    new APIParameter("code",authorizationCode),
                    new APIParameter("client_id",ConstantValue.ApiKey),
                    new APIParameter("client_secret",ConstantValue.SecretKey),
                    new APIParameter("redirect_uri",redirectUri),
                    new APIParameter("format","json")
                };
            string requestUrl = ConstantValue.OAuthUri.ToString();
            RenrenWebRequest client = new RenrenWebRequest();
            client.DownloadStringCompleted +=
                new RenrenWebRequest.DownloadStringCompletedHandler(callback);
            client.DownloadStringAsync(requestUrl, paras);
        }

        /// <summary>
        /// 通过传递Refresh Token的方式获得Access Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="callback"></param>
        public void GetAccessTokenByRefreshToken(string refreshToken,
            DownloadStringCompletedHandler callback)
        {
            // Refresh Token 第一次登录的时候获得Access Token的时候保存在APIKey.RefreshToken中，此处获得，不用用户指定。
            if (String.IsNullOrEmpty(refreshToken)) throw new ArgumentNullException("refreshToken required.");

            List<APIParameter> paras = new List<APIParameter>() { 
                new APIParameter("grant_type","refresh_token"),
                new APIParameter("refresh_token",refreshToken),
                new APIParameter("client_id",ConstantValue.ApiKey),
                new APIParameter("client_secret",ConstantValue.SecretKey)
            };
            RenrenWebRequest client = new RenrenWebRequest();
            client.DownloadStringCompleted +=
                new RenrenWebRequest.DownloadStringCompletedHandler(callback);
            client.DownloadStringAsync(ConstantValue.OAuthUri.ToString(), paras);
        }
    }
}
