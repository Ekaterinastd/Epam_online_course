using System;

namespace M6.Encaps.Inherit.Polymorph
{
    public abstract class Figure
    {
        public double X;
        public double Y;

        public Figure(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public abstract double GetPerimeter();
        public abstract double GetArea();
    }

    public class Circle : Figure
    {
        public double Radius { get; private set; }

        public Circle(double radius, double x = 0, double y = 0) : base(x, y)
        {
            if (radius < 0)
                throw new ArgumentException("Radius must be positive");
            Radius = radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius / 2;
        }
    }

    public class Triangle : Figure
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Triangle(double a, double b, double c, double x = 0, double y = 0) : base(x, y)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }

        /// <summary>
        /// Прощадь треугольника по формуле Герона
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public override double GetArea()
        {
            var halfOfPer = GetPerimeter() / 2;
            return Math.Sqrt(halfOfPer * (halfOfPer - A) * (halfOfPer - B) * (halfOfPer - C));
        }
    }

    public class Rectangle : Figure
    {
        public double Height { get; private set; }
        public double Width { get; private set; }

        public Rectangle(double height, double width, double x = 0, double y = 0) : base(x, y)
        {
            if (height <= 0 || width <= 0)
                throw new ArgumentException("Height and width must be positive");
            Height = height;
            Width = width;
        }

        public override double GetPerimeter()
        {
            return (Height + Width) * 2;
        }

        public override double GetArea()
        {
            return Height * Width;
        }
    }

    public class Square : Rectangle
    {
        public Square(double height, double width, double x = 0, double y = 0) : base(height, width, x, y)
        {

        }
    }


}
