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
using System.Windows.Data;
using System.Text.RegularExpressions;

namespace SDKSample.UIHelper
{
        public class BirthYearConverter : IValueConverter
        {

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;
                else if (Regex.IsMatch(value.ToString(), @"17\d{2}-\d{2}-\d{2}"))
                {
                    return Regex.Replace(value.ToString(), @"17(\d{2})-(\d{2})-(\d{2})", "$1后-$2-$3");
                }
                else
                    return value.ToString();
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    }
}
