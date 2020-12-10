using System;
using System.Linq;

namespace Introduction.Models
{
    public class Triangle
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public double Area => GetArea();
        public double Perimeter => GetPerimeter();
        public double GetArea()
        {
            double semiPerimeter = (Side1 + Side2 + Side3) / 2;
            return Math.Round(Math.Sqrt(semiPerimeter * (semiPerimeter - Side1) * (semiPerimeter - Side2) * (semiPerimeter - Side3)));
        }
        public double GetPerimeter()
        {
            return Side1 + Side2 + Side3;
        }
    }
}
