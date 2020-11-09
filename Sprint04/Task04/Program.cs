using System;
using System.Collections.Generic;
//Define an Interface IShape with declared method Area() returning 0 by default(double type)
//Define a class named Rectangle implementing the IShape interface.
//In this class, define Length and Width properties(double type)
//Implement the Area() method to calculate a rectangle area
//Define a class named Trapezoid implementing the IShape interface.
//In this class, define Length1, Length2 and Width properties(double type)
//Implement the Area() method to calculate a trapezoid area
//Define a generic class named Room<> depending on a shape of it's floor.
//Impose a constraint for type argument of the Room generic class so that it should implement the IShape interface
//In this class, define a Height property(double type) and the Floor property(type argument)
//Implement the Volume() method to calculate a volume of the room.
//Add an implementation of ICloneable interface for the Room<> class
//Implement deep cloning
//Add an implementation of IComparable interface for the Room<> class.
//Implement a comparison by area of the floor.
//Define a generic class RoomComparerByVolume<> implementing IComparer interface.
//Impose a constraint on the type argument so that it should implement the IShape interface.
//This comparer should perform comparison of rooms by room volume.
namespace Task04
{
    public interface IShape : ICloneable
    {
        double Area() => 0;
    }
    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Area() => Length * Width;
        public object Clone() => MemberwiseClone();
    }
    public class Trapezoid : IShape
    {
        public double Length1 { get; set; }
        public double Length2 { get; set; }
        public double Width { get; set; }
        public double Area() => 0.5 * (Length1 + Length2) * Width;
        public object Clone() => MemberwiseClone();
    }
    public class Room<T> : ICloneable, IComparable where T : IShape
    {
        public double Height { get; set; }
        public T Floor { get; set; }
        public double Volume() => Floor.Area() * Height;
        public object Clone()
        {
            T floor = (T)Floor.Clone();
            return new Room<T>() { Height = Height, Floor = floor };
        }
        public int CompareTo(object obj)
        {
            Room<T> room = obj as Room<T>;
            return Floor.Area().CompareTo(room.Floor.Area());
        }
    }
    public class RoomComparerByVolume<T> : IComparer<Room<T>> where T : IShape
    {
        public int Compare(Room<T> x, Room<T> y)
        {
            if (x.Volume() > y.Volume())
                return 1;
            if (x.Volume() < y.Volume())
                return -1;
            else
                return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Room<IShape> room = new Room<IShape>();
            room.Height = 10;
            room.Floor = new Rectangle() { Length = 100, Width = 10 };
            Room<IShape> room2 = new Room<IShape>();
            room2.Height = 10;
            room2.Floor = new Trapezoid() { Length1 = 10, Length2 = 10, Width = 20 };
            Console.WriteLine(room.Floor.Area());
            Console.WriteLine(room2.Floor.Area());
            Console.WriteLine(room.CompareTo(room2));
        }
    }
}
