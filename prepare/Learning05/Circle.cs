using System;

namespace Learning05
{
    public class Circle : Shape
    {
        // Attributes 
        private double _radius = 0;
        private const double PI = 3.1415926535897931;

        // Constructors
        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }

        // Methods
        public override double GetArea()
        {
            return Math.Round(PI * (_radius * _radius), 2);
        }
    }
    
}
