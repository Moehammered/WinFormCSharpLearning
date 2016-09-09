using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ShapeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a list that only stores shapes
            List<Shape> shapes = new List<Shape>();

            // add 3 different shapes
            shapes.Add(new Rectangle(10.5, 8.9, "Green"));
            shapes.Add(new Circle(4, "Blue"));
            shapes.Add(new Triangle(16, 11.11, "Yellow"));

            // print each shape in the list
            foreach (Shape s in shapes)
            {
                Console.WriteLine(s.ToString());
                Console.WriteLine("Area = {0:f2}", s.Area);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
