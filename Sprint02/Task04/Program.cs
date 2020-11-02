using System;
//Create three classes: ChessFigure, Bishop and Rook. Organize inheritance in the correct way.
//Class Bishop should have void method Move() that outputs the message "Moves by a diagonal!".
//Class Rook should have void method Move() that outputs the message "Moves straight!".
//Every class that is derived from class ChessFifure must implement void method Move().
namespace Task04
{
    public abstract class ChessFigure
    {
        public abstract void Move();
    }
    public class Bishop : ChessFigure
    {
        public override void Move()
        {
            Console.WriteLine("Moves by a diagonal!");
        }
    }
    public class Rook : ChessFigure
    {
        public override void Move()
        {
            Console.WriteLine("Moves straight!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
