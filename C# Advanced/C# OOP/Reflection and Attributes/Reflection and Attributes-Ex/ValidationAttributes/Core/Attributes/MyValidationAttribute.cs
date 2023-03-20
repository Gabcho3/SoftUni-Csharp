using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal abstract class MyValidationAttribute : Attribute, IValidator
    {
        public abstract bool IsValid(object obj);
    }
}
