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
using RenrenSDKLibrary;
using System.IO;
using System.Text;

namespace SDKSample.Views
{
    public partial class RestAPIPage : PhoneApplicationPage
    {
        public RestAPIPage()
        {
            InitializeComponent();
        }

        private void Publish_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (tb_blogtitle.Text == "")
                MessageBox.Show("请输入日志标题");
            else if (tb_blogcontent.Text == "")
                MessageBox.Show("请输入日志内容");
            else
            {
                List<APIParameter> param = new List<APIParameter>();
                param.Add(new APIParameter("method","blog.addBlog"));
                param.Add(new APIParameter("title",tb_blogtitle.Text));
                param.Add(new APIParameter("content",tb_blogcontent.Text));

                App.api.RequestAPIInterface(PublishBlogCompletedCallBack, param);
            }
        }

        private void PublishBlogCompletedCallBack(object sender, APIRequestCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    //获取blog的id
                    BlogID blogId = new BlogID();
                    blogId = (BlogID)JsonUtility.DeserializeObj(
                        new MemoryStream(Encoding.UTF8.GetBytes(e.ResultJsonString)), typeof(BlogID));
                    MessageBox.Show("创建成功");
                    tb_result.Text = "id: " + blogId.id;
                }
                catch
                {
                    MessageBox.Show("encoding error");
                }
            }
            else
                MessageBox.Show(e.Error.Message);
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }
    }

    public class BlogID
    {
        public string id { get; set;}
    }

}