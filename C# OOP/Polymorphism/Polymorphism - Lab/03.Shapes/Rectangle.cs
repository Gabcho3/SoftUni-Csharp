using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculatePerimeter()
            => height * 2 + width * 2;

        public override double CalculateArea()
            => height * width;
    }
}
