﻿#pragma checksum "E:\Projects\WP7 SDK v2.0\RenrenSDKLibrary\Controls\BrowserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "42EBC2D9991F5574D202214C349C6308"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace RenrenSDKLibrary.Controls {
    
    
    public partial class BrowserControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.WebBrowser RenrenBrowser;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/RenrenSDKLibrary;component/Controls/BrowserControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.RenrenBrowser = ((Microsoft.Phone.Controls.WebBrowser)(this.FindName("RenrenBrowser")));
        }
    }
}

