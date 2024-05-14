using System.Collections.ObjectModel;
using System.Globalization;

namespace Contador.Converters
{
    public class AutoWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<string> items)
            {
                var valueString = string.Empty;
                foreach (var item in items) valueString += " " + item;

                
                if (valueString.Length <= 14) return 50;
                if (valueString.Length <= 15) return 46;
                if (valueString.Length <= 16) return 42;
                //if (valueString.Length <= 19) return 10;
                //if (valueString.Length <= 21) return 10;
                //if (valueString.Length <= 23) return 10;
                //if (valueString.Length <= 25) return 10;
                //if (valueString.Length <= 27) return 10;
                //if (valueString.Length <= 29) return 10;
                //if (valueString.Length <= 31) return 10;
            }
            return 10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
}
