using System;

namespace ObjectPrinting;

public static class PropertyPrintingConfigExtensions
{
    public static string PrintToString<T>(this T obj, Func<PrintingConfig<T>, PrintingConfig<T>> config)
    {
        return config(ObjectPrinter.For<T>()).PrintToString(obj);
    }

    public static PrintingConfig<TOwner> TrimmedToLength<TOwner>(this PropertyPrintingConfig<TOwner, string> propConfig, int maxLen)
    {
        var propertyConfig = (IPropertyPrintingConfig<TOwner, string>)propConfig;
        var printingConfig = (IPrintingConfig<TOwner>)propertyConfig.ParentConfig;
        printingConfig.PropertiesToTrim[propertyConfig.Property] = maxLen;
        return propertyConfig.ParentConfig;
    }

}