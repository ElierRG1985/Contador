using System.Collections.ObjectModel;
using System.Globalization;

namespace Contador.Converters
{
    public class OperationsToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = "";
            if (value is ObservableCollection<string> items)
            {
                foreach (var item in items)
                {
                    //if (!string.IsNullOrEmpty(result)) result += " ";
                    result += " " + item;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
}
