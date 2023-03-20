﻿using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Core.Classes;

namespace ValidationAttributes.Core.Attributes
{
    internal class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            return (int)obj >= minValue && (int)obj <= maxValue;
        }
    }
}
