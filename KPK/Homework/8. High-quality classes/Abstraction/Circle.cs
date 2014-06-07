using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius;

        public double Radius { get { return this.radius; } }

        public Circle()
            : this(1)
        {
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
