using System.Globalization;

namespace Punjab_Ornaments.Presentation.Converters
{
    class ApprovaltoColour : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Colors.White;

            return (int)value switch
            {
                0 => Colors.LightGoldenrodYellow,
                1 => Colors.LightBlue,
                _ => Colors.White,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
