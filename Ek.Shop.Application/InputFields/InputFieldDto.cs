using System;
using System.Collections.Generic;

namespace Ek.Shop.Application.InputFields
{
    public class InputFieldDto
    {
        public Dictionary<string, object> Characteristics { get; set; }

        public object Value { get; set; }

        public T GetValue<T>()
        {
            if (Value == null)
            {
                return default(T);
            }
            else
            {
                if (Value is T)
                {
                    return (T)Value;
                }
                else
                {
                    // Allow convert nullable types
                    var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                    try
                    {
                        return (T)Convert.ChangeType(Value, type);
                    }
                    catch
                    {
                        return default(T);
                    }
                }
            }
        }

        public void SetCharacteristic(string code, object value)
        {
            Characteristics[code] = value;
        }
    }
}
