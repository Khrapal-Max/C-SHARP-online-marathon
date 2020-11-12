using System;
using System.Collections.Generic;
using System.Linq;
//In class MyProgram :
//  1) Create a method that should take a collection of arguments Position(List<int> numbers) in which find and Console.WriteLine all positions of element 5 in this collection
//  2) Create a method that should take a collection of arguments Remove(List<int> numbers) in which remove from collection all elements, which are greater than 20. and print collection
//  3) Create a method that should take a collection of arguments Insert(List<int> numbers)  in which insert elements -5,-6,-7 in positions 3, 6, 8 and print collection
//  4) Create a method that should take a collection of arguments Sort(List<int> numbers) in which sorting collection with LINQ and print collection
namespace Level01Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 3, 5, 9, 11, 5, 5, 20, 22, 25 };
            Position(numbers);
            Remove(numbers);
            Insert(numbers);
            Sort(numbers);
        }
        static void Position(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == 5)
                    Console.WriteLine(i + 1);
            }
        }
        static void Remove(List<int> numbers)
        {
            numbers.Where(x => x <= 20).ToList().ForEach(x => Console.WriteLine(x));
        }
        static void Insert(List<int> numbers)
        {
            numbers.Insert(2, -5);
            numbers.Insert(5, -6);
            numbers.Insert(7, -7);
            numbers.ForEach(x => Console.WriteLine(x));
        }
        static void Sort(List<int> numbers)
        {
            numbers.Sort();
            numbers.ForEach(x => Console.WriteLine(x));
        }
    }
}
