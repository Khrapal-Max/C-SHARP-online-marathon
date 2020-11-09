using System;
//Define an interface IAnimal with property Name, methods Voice() and Feed()
//Define two classes Cat and Dog, which implement this interface.
//For the class Dog,
//the Voice() method should print "Woof" on the Console,
//the Feed() method should print "I eat meat" on the Console.
//For the class Cat,
//the Voice() method should print "Mew" on the Console,
//the Feed() method should print "I eat mice" on the Console.
namespace Task02
{
    interface IAnimal
    {
        public string Name { get; set; }
        void Voice();
        void Feed();
    }
    class Dog : IAnimal
    {
        public string Name { get; set; }        
        public void Voice() => Console.WriteLine("Woof");
        public void Feed() => Console.WriteLine("I eat meat");
    }
    class Cat : IAnimal
    {
        public string Name { get; set; }
        public void Voice() => Console.WriteLine("Mew");
        public void Feed() => Console.WriteLine("I eat mice");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
