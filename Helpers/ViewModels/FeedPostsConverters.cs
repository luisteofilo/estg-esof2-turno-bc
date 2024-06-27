using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace Helpers.ViewModels;

public class FeedPostConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string? stringValue;
        
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPost>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPost feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class FeedPostUserConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string? stringValue;
        
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPostUser>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPostUser feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class FeedPostMediaConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string? stringValue;
        
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPostMedia>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPostMedia feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class FeedPostHashtagConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string? stringValue;
        
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPostHashtag>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPostHashtag feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class FeedPostWineConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string? stringValue;
        
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPostWine>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPostWine feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class FeedPostWineBrandConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string? stringValue;
        
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPostWineBrand>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPostWineBrand feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class FeedPostEventConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string? stringValue;
        
        stringValue = value as string;

        if (!string.IsNullOrEmpty(stringValue))
        {
            return JsonSerializer.Deserialize<FeedPostEvent>(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }
    
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }
    
    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is FeedPostEvent feedPost)
        {
            return JsonSerializer.Serialize(feedPost);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

