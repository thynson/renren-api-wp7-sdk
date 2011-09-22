//  Copyright 2011年 Renren Inc. All rights reserved.
//  - Powered by Team Pegasus. -

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
using Microsoft.Phone.Tasks;
using System.IO;
using RenrenSDKLibrary;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace SDKSample
{
    public partial class UploadPhoto : PhoneApplicationPage
    {
        private readonly PhotoChooserTask photoTask = new PhotoChooserTask();
        RenrenAPI api = App.api;
        private BitmapImage image;
        private string fileName;

        /// <summary>
        /// 构造
        /// </summary>
        public UploadPhoto()
        {
            InitializeComponent();
            photoTask.Completed += MyPhotoChooser_Completed;
        }

        private void SelectPhoto_Btn_Click(object sender, RoutedEventArgs e)
        {
            photoTask.Show();
        }
       
        void MyPhotoChooser_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                image = new BitmapImage();
                image.SetSource(e.ChosenPhoto);              
                fileName = e.OriginalFileName;
                ChosenPhoto.Source = image;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            api.PublishPhoto(image, fileName, UphotPhoto_DownloadStringCompleted,
                textBox1.Text);
        }


        private void UphotPhoto_DownloadStringCompleted(object sender,
             RenrenSDKLibrary.UploadPhotoCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.textBox2.Text = e.Error.ToString();
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                this.textBox2.Text = e.Result.ToString();
                MessageBox.Show("上传成功");
                BitmapImage smallImage = new BitmapImage();
                smallImage.UriSource = new Uri( e.Result.src_small, UriKind.RelativeOrAbsolute);
                image1.Source = smallImage;
            }
            
        }

        private void Log_Btn_Clicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LogPage.xaml", UriKind.Relative));
        }
    }
}