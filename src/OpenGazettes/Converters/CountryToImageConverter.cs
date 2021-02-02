using System;
using System.Globalization;
using Xamarin.Forms;

namespace OpenGazettes.Converters
{
    public class CountryToImageConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                switch (value)
                {
                    case "Western Cape Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/westerncape.jpg";

                    case "South African Government Gazettes":
                        return "https://opengazettes.org.za/img/provinces/national_4.jpg";

                    case "Gauteng Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/gauteng.jpg";

                    case "Limpopo Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/limpopo.jpg";

                    case "Mpumalanga Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/mpumalanga.jpg";

                    case "Northern Cape Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/northerncape.jpg";

                    case "KwaZulu-Natal Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/kwazulunatal.jpg";

                    case "North West Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/northwest.jpg";

                    case "Eastern Cape Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/easterncape.jpg";

                    case "Free State Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/freestate.jpg";

                    case "Transvaal Provincial Gazettes":
                        return "https://opengazettes.org.za/img/provinces/transvaal.jpg";

                    default:
                        return "";
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion IValueConverter Members
    }
}