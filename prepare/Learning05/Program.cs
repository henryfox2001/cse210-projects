using System;
using System.Drawing;

namespace Learning05
{
    class Program
    {
        public string shapeColor = "Green";
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Square shape1 = new Square("Green", 8);
            shapes.Add(shape1);

            Rectangle shape2 = new Rectangle("Yellow", 6, 17);
            shapes.Add(shape2);

            Circle shape3 = new Circle("Blue", 5);
            shapes.Add(shape3);

            foreach (Shape shapeIndex in shapes)
            {
                string color = shapeIndex.GetColor();
                double area = shapeIndex.GetArea();

                Console.WriteLine($"The {color} shape has an area of {area}.");
            }
        }
    }
}