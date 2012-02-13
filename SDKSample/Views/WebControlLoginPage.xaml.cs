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

namespace SDKSample.Views
{
    public partial class WebControlLoginPage : PhoneApplicationPage
    {
        public WebControlLoginPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Fired when oauthControl is navigating
            oauthControl.OAuthBrowserNavigating = new EventHandler(oauthBrowserNavigating);

            // Fired when oauthControl is navigated
            oauthControl.OAuthBrowserNavigated = new EventHandler(oauthBrowserNavigated);

            // Fired when oauthControl's cancel button is pressed
            oauthControl.OAuthBrowserCancelled = new EventHandler(oauthBrowserCancelled);

            oauthControl.LoginCompleted += new LoginCompletedHandler(renren_LoginCompletedHandler);
        }

        private void oauthBrowserNavigating(object sender, EventArgs e)
        {

        }

        private void oauthBrowserNavigated(object sender, EventArgs e)
        {
 
        }

        private void oauthBrowserCancelled(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        public void renren_LoginCompletedHandler(object sender, LoginCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                NavigationService.Navigate(new Uri("/Views/FeaturePage.xaml?prepage=webcontrolpage", UriKind.Relative));
            }
            else
                MessageBox.Show(e.Error.Message);
        }
    }
}