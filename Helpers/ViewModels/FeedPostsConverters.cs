using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace Helpers.ViewModels;

public class FeedPostConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        string stringValue;
        object result;

        result = null;
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPost>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPost feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

