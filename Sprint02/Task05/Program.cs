using System;
//For finish, let’s talk about the cats. The big cats.
//Please, create class Acinonychini. This class has two sub-classes, that live now: Acinonyx and Puma.
//Create these sub-classes too. It’s known that Puma has sub-classed and they may be created later. Acinonyx has no sub-classed, so it’s sub-classes can’t be created anywhen.
//Create For all the classes those fields, properties and methods that you think they need.
namespace Task05
{
    public class Acinonychini  {  }
    internal sealed class Acinonyx : Acinonychini  {  }
    public class Puma : Acinonychini  {  }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
