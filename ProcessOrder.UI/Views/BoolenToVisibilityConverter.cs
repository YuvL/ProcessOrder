using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ProcessOrder.UI.Views
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolenToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public bool IsInverse { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new InvalidOperationException("The target must be a Visibility");

            var isVisible = IsInverse ? !(bool) value : (bool) value;

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
