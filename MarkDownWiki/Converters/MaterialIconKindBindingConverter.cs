using Avalonia.Data.Converters;
using Material.Icons;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWiki.Converters;

public class MaterialIconKindBindingConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not MaterialIconKind iconKind) throw new ArgumentException("Value is not MaterialIconKind.");

        return Enum.GetName(iconKind);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}