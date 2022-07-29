using System;
namespace MahdaviEshop.Framework.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnumString<T>(this string value)
        {
            Enum.TryParse(typeof(T), value, out object result);
            return (T)result;
        }

        public static T ToEnumInt<T>(this int value)
        {
           return (T) Enum.ToObject(typeof(T), value);
        }

    }
}
