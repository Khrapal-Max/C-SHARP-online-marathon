using System;
//Define an Interface ISwimmable with declared method Swim() printinging the text "I can swim!" by default.
//Define an interface IFlyable with read-only property MaxHeight returning 0 by default (use default implementation for this property).
//In this interface, declare a method Fly() printing the text "I can fly at XX meters height!" by default, where XX is the value of MaxHeight property.
//Define an interface IRunnable with read-only property MaxSpeed returning 0 by default (use default implementation for this property).
//In this interface, declare a method Run() printing the text "I can run up to XX kilometers per hour!" by default, where XX is the value of MaxSpeed property.
//Define an interface IAnimal with read-only property LifeDuration returning 0 by default (use default implementation for this property).
//In this interface, declare a method Voice() printing the text "No voice!" by default.
//Besides, declare a method ShowInfo() printing the text "I am a XX and I live approximately YY years." by default,//where XX is the name of the class implementing the interface,
//YY is the value of LifeDuration property.
//Define a class named Cat implementing the IAnimal and IRunnable interface.
//In this class, implement autoproperties as needed.
//Implement the Voice() method printing "Meow!"
//Define a class named Eagle implementing the IAnimal and IFlyable interface.
//In this class, implement autoproperties as needed.
//Define a class named Shark implementing the IAnimal and ISwimmable interface.
//In this class, implement autoproperties as needed.
namespace Task01
{
    interface ISwimmable
    {
        public void Swim() => Console.WriteLine("I can swim!");
    }
    interface IFlyable
    {
        public int MaxHeight => 0;
        public void Fly() => Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }
    interface IRunnable
    {
        public int MaxSpeed => 0;
        public void Run() => Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }
    interface IAnimal
    {
        public int LifeDuration => 0;
        public void Voice() => Console.WriteLine("No voice!");
        public void ShowInfo() => Console.WriteLine($"I am a {GetType()} and I live approximately {LifeDuration} years.");
    }
    class Cat : IAnimal, IRunnable
    {
        public int MaxSpeed { get; set; }
        public int LifeDuration { get; set; }
        public void Voice() => Console.WriteLine("Meow!");
    }
    class Eagle : IAnimal, IFlyable
    {
        public int MaxHeight { get; set; }
        public int LifeDuration { get; set; }
    }
    class Shark : IAnimal, ISwimmable
    {
        public int LifeDuration { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.MaxSpeed = 60;
            cat.LifeDuration = 100;
            ((IRunnable)cat).Run();
            ((IAnimal)cat).ShowInfo();
            Eagle eagle = new Eagle();
            eagle.MaxHeight = 800;
            eagle.LifeDuration = 80;
            ((IFlyable)eagle).Fly();
            ((IAnimal)eagle).ShowInfo();
            Shark shark = new Shark();
            shark.LifeDuration = 120;
            ((ISwimmable)shark).Swim();
            ((IAnimal)shark).ShowInfo();
            Console.WriteLine("Hello World!");
        }
    }
}
