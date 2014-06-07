using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public double Width { get { return width; } }
        public double Height { get { return height; } }

        public Rectangle()
            : this(1, 1)
        {
        }

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
