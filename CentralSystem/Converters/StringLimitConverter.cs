using System.Globalization;

namespace CentralSystem.Converters
{
    public class StringLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object maxLenght, CultureInfo culture)
        {
            var hasLen = int.TryParse(maxLenght as string, out int len);
            if (hasLen == false) throw new ArgumentException($"Argument {nameof(maxLenght)} is invalid or null.");

            var s = value as string;
            if (len < s.Length)
                return $"{s.Substring(0, len)} ...";
            else 
                return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
