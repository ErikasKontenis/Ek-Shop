using System;
using System.Globalization;

namespace Ek.Shop.Core.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ToDecimal(this object value)
        {
            if (null == value)
                return 0.00m;

            try
            {
                return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return 0.00m;
            }
        }
    }
}
