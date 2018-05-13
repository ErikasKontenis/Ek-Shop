using System;

namespace Ek.Shop.Core.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsNumericType<TSource>(this TSource source)
        {
            switch (Type.GetTypeCode(source.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
