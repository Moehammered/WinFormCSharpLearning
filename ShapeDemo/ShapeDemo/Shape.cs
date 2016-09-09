
namespace ShapeDemo
{
    public abstract class Shape
    {
        protected string color;

        public abstract double Area
        {
            get;
        }

        public Shape(string color)
        {
            this.color = color;
        }

        public override abstract string ToString();
    }
}
