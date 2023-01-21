using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PR2Konst
{
    [ValueConversion(typeof(TypeOfSerialiaze), typeof(string))]
    public class TypeOfSerialiazeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TypeOfSerialiaze typeOfSerialiaze = (string)value switch
            {
                "XML" => TypeOfSerialiaze.XML,
                "JSON" => TypeOfSerialiaze.JSON,
                "BIN" => TypeOfSerialiaze.BIN,
            };
            return typeOfSerialiaze;
        }
    }
}
