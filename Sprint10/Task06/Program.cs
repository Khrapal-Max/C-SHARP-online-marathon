using System;
//Little boy Jimmy likes his pets and is found of programming.
//Jimmy has cat Tom, duck McDuck, sparrow Sparry and parrot Leya. Jimmy decided to write a program to have a little report about pets' habits. 
//But Leya is very clever parrot. She knows about SOLID principles and LSP she loves most of all. She didn't like the Jimmy's code. So she mixed all the classes, methods and interfaces.
//At least Jimmy has only identifiers: Bird, Cat, Parrot, Duck, IFlyable, IEating, IMoving, Fly, Eat, Move, IBasking, IKryaking, Bask, Krya.And he remembers that every method have to output one habit of one pet.
//Please, define all the types and their members to help Jimmy to see the result as follows:
//sp10_6
//By the way, Leya, like every good parrot, likes to imitate the habits of every Jimmy's pet.
namespace Task06
{
    interface IFlyable
    {
        void Fly();
    }
    interface IEating
    {
        void Eat();
    }
    interface IMoving
    {
        void Move();
    }
    interface IBasking
    {
        void Bask();
    }
    interface IKryaking
    {
        void Krya();
    }
    class Bird : IFlyable, IEating, IMoving
    {
        public void Eat() => Console.WriteLine("Oh! My corn!");
        public void Fly() => Console.WriteLine("I believe, I can fly");
        public void Move() => Console.WriteLine("I can jump!");
    }
    class Cat : IMoving, IEating, IBasking
    {
        public void Bask() => Console.WriteLine("Mrrr-Mrrr-Mrrr...");
        public void Eat() => Console.WriteLine("Oh! My milk!");
        public void Move() => Console.WriteLine("I can jump!");
    }
    class Parrot : Bird, IBasking, IKryaking
    {
        public void Bask() => Console.WriteLine("Chuh-Chuh-Chuh...");
        public void Krya() => Console.WriteLine("Krya-Krya-Krya...");
        public new void Eat() => Console.WriteLine("Oh! My seeds and fruits!");
        public new void Move() => Console.WriteLine("I can jump!");
    }
    class Duck : Bird, IKryaking
    {
        public void Krya() => Console.WriteLine("Krya-Krya!");
        public new void Move() => Console.WriteLine("I can swimm!");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parrot leya:");
            Parrot parrot = new Parrot();
            parrot.Fly();
            parrot.Bask();
            parrot.Krya();
            parrot.Eat();
            parrot.Move();
            Console.WriteLine();
            Console.WriteLine("Sparrow Sparry:");
            Bird sparry = new Bird();
            sparry.Fly();
            sparry.Eat();
            sparry.Move();
            Console.WriteLine();
            Console.WriteLine("Duck McDuck:");
            Duck mcDuck = new Duck();
            mcDuck.Fly();
            mcDuck.Eat();
            mcDuck.Krya();
            mcDuck.Move();
            Console.WriteLine();
            Console.WriteLine("Cat Tom:");
            Cat cat = new Cat();
            cat.Move();
            cat.Eat();
            cat.Bask();
        }
    }
}
