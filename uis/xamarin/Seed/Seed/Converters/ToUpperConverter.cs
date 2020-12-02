using System;
using System.Globalization;
using Xamarin.Forms;

namespace Seed.Converters
{
    public class ToUpperConverter : IValueConverter
    {
        //Convert value from ViewModel to UI 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().ToUpper();
        }

        //Convert value from UI to ViewModel
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
