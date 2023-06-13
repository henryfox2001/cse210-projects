using System;

namespace Learning05
{
    public class Circle : Shape
    {
        // Attributes 
        private double _radius = 0;

        // Constructors
        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }

        // Methods
        public override double GetArea()
        {
            return Math.Round(Math.PI * (_radius * _radius), 2);
        }
    }

}
