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

namespace RenrenSDKLibrary
{
    public class ConstantValue
    {
        //ApiKey SecretKey后续需要删除
        public static string ApiKey = "5c825fb9b30c494cb48e674e21139f20";

        public static string SecretKey = "510991aed48945e4ae48f4481b33859c";
        //授权验证Uri
        public static Uri OAuthUri = new Uri("https://graph.renren.com/oauth/token", UriKind.Absolute);
        //开放平台Uri
        public static Uri RequestUri = new Uri("http://api.renren.com/restserver.do",UriKind.Absolute);
        //重定向Uri
        public static string Redirect_Uri = "http://graph.renren.com/oauth/login_success.html";

        public static string LoginAuth = "https://graph.renren.com/oauth/authorize?";

        public static string SessionURL = "https://graph.renren.com/renren_api/session_key";

        public static string WidgetDialog = "http://widget.renren.com/dialog/";

        public static string PostMethod = "POST";

        public static string GetMethod = "GET";
    }

    // http method
    public enum HttpMethod
    {
        POST,
        GET
    }
}
