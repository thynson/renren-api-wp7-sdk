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
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace RenrenSDKLibrary.WidgetDialog
{
    public class NewfeedWidgetDialog : WidgetDialog
    {
 
        #region public function
        /// <summary>
        /// 显示dialog
        /// </summary>
        /// <param name="requiredParam"></param>
        /// <param name="optionalParam"></param>
        public void RunDialog(NewfeedDialogRequired requiredParam, 
            NewfeedDialogOptional optionalParam)
        {
            if (requiredParam == null || requiredParam.HasEmptyMember())
            {
                return;
            }
            browserControl.LoadCompleted -=
                 new BrowserControl.LoadCompletedEventHandler(RenrenBrowser_LoadCompleted);
            browserControl.LoadCompleted +=
                 new BrowserControl.LoadCompletedEventHandler(RenrenBrowser_LoadCompleted);

            string uri = ConstantValue.WidgetDialog;
            uri += "feed?" +
                "ua=cb02a891540976afd5b1b42413fb83af" +
                "&app_id=" + requiredParam.app_id +
                "&url=" + requiredParam.url +
                "&redirect_uri=" + requiredParam.redirect_uri +
                "&name=" + requiredParam.name +
                "&description=" + requiredParam.description +
                "&display=" + "touch";
            string optionUri = null ;
            if (optionalParam != null)
            {
                if (optionalParam.action_link != null)
                    optionUri += "&action_link=" + optionalParam.action_link;
                if (optionalParam.action_name != null)
                    optionUri += "&action_name=" + optionalParam.action_name;
                if (optionalParam.caption != null)
                    optionUri += "&caption=" + optionalParam.caption;
                if (optionalParam.image != null)
                    optionUri += "&image=" + optionalParam.image;
            }
            if (RenrenSDK.RenrenInfo.userInfo.scope != null)
            {
                if (RenrenSDK.RenrenInfo.userInfo.scope.Contains("publish_feed"))
                {
                    uri += "&access_token=" + RenrenSDK.RenrenInfo.userInfo.access_token;
                }
            } 
            uri += optionUri;
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
            if(flag == "success")
            {
                NotifyMessage(flag);
            }
        }
        #endregion
    }
}
