using System.IO;

namespace ShapeDemo
{
    public class Rectangle : Shape
    {
        private double width, height;

        public Rectangle(double width, double height, string color) : base(color)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area
        {
            get
            {
                return width * height;
            }
        }

        public override string ToString()
        {
            StringWriter sw = new StringWriter();
            sw.Write("Rectangle of color {0}, height {1:f2} and width {2:f2}", color, height, width);
            return sw.ToString();
        }
    }
}
