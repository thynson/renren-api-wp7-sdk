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
using RenrenSDKLibrary.Controls;
using Microsoft.Phone.Controls;
using RenrenSDKLibrary.Constants;

namespace RenrenSDKLibrary.WidgetDialog
{
    public class LikeWidgetDialog : WidgetDialog
    {
        string appId;

        #region public function
        /// <summary>
        /// 显示dialog
        /// </summary>
        /// <param name="requiredParam"></param>
        /// <param name="optionalParam"></param>
        public void RunDialog(string like_url, string app_id)
        {
            if (like_url == null)
            {
                return;
            }
            browserControl.LoadCompleted -=
                 new BrowserControl.LoadCompletedEventHandler(RenrenBrowser_LoadCompleted);
            browserControl.LoadCompleted +=
                 new BrowserControl.LoadCompletedEventHandler(RenrenBrowser_LoadCompleted);
            appId = app_id;
            string uri = ConstantValue.WidgetDialog;
            uri += "like?" +
                "ua=cb02a891540976afd5b1b42413fb83af" +
                "&redirect_uri=" + "http://app.renren.com" +
                "&like_url=" + like_url+
                "&display=" + "touch";

            if (RenrenSDK.RenrenInfo.userInfo.scope != null)
            {
                if (RenrenSDK.RenrenInfo.userInfo.scope.Contains("operate_like"))
                {
                    uri += "&access_token=" + RenrenSDK.RenrenInfo.userInfo.access_token;
                }
            }
            if (browserControl != null)
            {
                browserControl.SetUri(uri);
            }
            else
            {
                return;
            }
        }
        #endregion

        #region private function
        /// <summary>
        /// 网页加载成功的回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenrenBrowser_LoadCompleted(object sender,
            NavigatingEventArgs e)
        {
            string error = getQuerystring(new Uri(e.Uri.ToString()), "error");
            if (error == "access_denied")
            {
                RemoveBrowser();
            }
            else if (error == "login_denied")
            {
                RemoveBrowser();
            }
            else if (error != "")
            {
                NotifyError(error);
            }
            string flag = getQuerystring(new Uri(e.Uri.ToString()), "flag");
            if (flag != "")
            {
                NotifyMessage(flag);
            }
        }
        #endregion
    }
}
