using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using TpvlDataAnalyzer.Model;

namespace TpvlDataAnalyzer.View.Converter
{
    public class SortCriterionToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PlayerSortCriterion current &&
                parameter is PlayerSortCriterion self &&
                current == self)
            {
                return Brushes.Red;
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class SortCriterionToBrushMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return Brushes.Black;

            if (values[0] is PlayerSortCriterion current &&
                values[1] is PlayerSortCriterion self &&
                current == self)
            {
                return Brushes.Red;
            }

            return Brushes.Black;
        }

        public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => null;
    }
}