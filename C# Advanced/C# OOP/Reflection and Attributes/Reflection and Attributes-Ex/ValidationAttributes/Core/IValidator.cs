using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Core
{
    internal interface IValidator
    {
        bool IsValid(object obj);
    }
}
