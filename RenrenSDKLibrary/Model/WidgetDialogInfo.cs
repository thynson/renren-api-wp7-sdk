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
    public class NewfeedDialogRequired
    {
        /// <summary>
        /// 应用app_id
        /// </summary>
        public string app_id { get; set; }

        /// <summary>
        /// 新鲜事标题及图片的链接
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 点击确定或取消后跳转的url。
        /// </summary>
        public string redirect_uri { get; set; }

        /// <summary>
        /// 新鲜事标题。注意：此字段最长为30字符。 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 新鲜事主题内容。注意：此字段最长为120字符。
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 必填字段，不能为空
        /// </summary>
        /// <returns></returns>
        public bool HasEmptyMember()
        {
            if (app_id == null || url == null || redirect_uri == null 
                || name == null || description == null)
            {
                return true;
            }
            return false;
        }
    }

    public class NewfeedDialogOptional
    {
        /// <summary>
        /// 新鲜事副标题。注意：此字段最长为20字符。
        /// </summary>
        public string caption { get; set; }

        /// <summary>
        /// 新鲜事图片链接。 
        /// </summary>
        public string image { get; set; }

        /// <summary>
        /// 新鲜事动作模块文案。注意：此字段最长为10字符。 
        /// </summary>
        public string action_name { get; set; }

        /// <summary>
        /// 新鲜事动作模块链接。 
        /// </summary>
        public string action_link { get; set; }
    }
}
