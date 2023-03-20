using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using ValidationAttributes.Core.Attributes;

namespace ValidationAttributes.Core.Classes
{
    internal static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes<MyValidationAttribute>().ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
