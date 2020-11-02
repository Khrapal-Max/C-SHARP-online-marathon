using System;

//Create a Point class which models a 2D point with x and y coordinates should contain:
//Two instance variables x and y  of int type, that will be available only in this class.
//A constructor that constructs a point with the given x and y coordinates.
//A method GetXYPair() which returns the x and y in a 2-element int array. This method should be available everywhere in the current assembly
//A method called Distance(int x, int y) that returns the distance from this point to another point at the given (x, y) coordinates.
//An overloaded Distance(Point point) method that returns the distance from this point to the given Point instance.
//The distance methods should be available everywhere in the current assembly and in descendant classes in other assemblies;
//Create explicit cast to double operator that returns the distance from this point to the origin (0, 0).
namespace Task02
{
    public class Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        internal int[] GetXYPair()
        {
            return new int[] { x, y };
        }
        protected internal double Distance(int x, int y)
        {
            return Math.Sqrt(Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2)); 
        }
        protected internal double Distance(Point point)
        {
            return Math.Sqrt(Math.Pow(point.x - x, 2) + Math.Pow(point.y - y, 2));
            /*
            /Правильное решение - ментор
            return Distance(point.x, point.y);
            */
        }
        public static explicit operator double(Point point)
        {
            return point.Distance(0, 0);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point(0, 0);
            Point b = new Point(0, 4);
            Console.WriteLine((a.Distance(3, 4)));
            Console.ReadLine();
        }
    }
}
