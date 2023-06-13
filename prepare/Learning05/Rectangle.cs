using System;

namespace Learning05
{
    public class Rectangle : Shape
    {
        // Attributes 
        private double _length = 0;
        private double _width = 0;

        // Constructors
        public Rectangle(string color, double length, double width) : base(color)
        {
            _length = length;
            _width = width;
        }

        // Methods
        public override double GetArea()
        {
            return _length * _width;
        }
    }
}
