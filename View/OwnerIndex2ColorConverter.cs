using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_MAUI_AttaxxPlus.View
{
    public class OwnerIndex2ColorConverter : IValueConverter
    {
        // Note: reusing brushes for all calls,
        //  using array instead of switch in Convert.
        readonly private static Color[] colors = new[] { Colors.Gray, Colors.Red, Colors.Blue };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return colors[(int)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}