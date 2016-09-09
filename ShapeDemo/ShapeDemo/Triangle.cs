using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ShapeDemo
{
    class Triangle : Shape
    {
        private double height, width;

        public Triangle(double h, double w, string c)
            : base(c)
        {
            height = h;
            width = w;
        }

        public override double Area
        {
            get { return height * width / 2; }
        }

        public override string ToString()
        { 
            StringWriter sw = new StringWriter();
            sw.Write("Triangle of color {0}, height {1:f2} and base width {2:f2}", color, height, width);
            return sw.ToString();
        }
    }
}
