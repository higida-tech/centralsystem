using CommunityToolkit.Maui.Behaviors;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CentralSystem.Converters
{
    public class StringToPhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;
            var ddd = s.Substring(0, 2);
            var first_half = s.Substring(2, 5);
            var last_half = s.Substring(7, 4);
            return $"({ddd}) {first_half}-{last_half}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;
            Regex rx1 = new Regex(@"(?!\d).");
            return rx1.Replace(s, string.Empty);
        }
    }
}


