using System;
using System.IO;

namespace ShapeDemo
{
    class Circle : Shape
    {
        private double radius;

        public Circle(double r, string c)
            : base(c)
        {
            radius = r;
        }

        public override double Area
        {
            get { return radius * radius * Math.PI; }
        }

        public override string ToString()
        {
            StringWriter sw = new StringWriter();
            sw.Write("Circle with color {0} and radius {1:f2}", color, radius);
            return sw.ToString();
        }
    }
}
