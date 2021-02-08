using System;
using System.Globalization;
using Xamarin.Forms;

namespace OpenGazettes.Converters
{
    public class ViewerUrlConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Uri)
            {
                return "https://docs.google.com/viewer?url=" + value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}