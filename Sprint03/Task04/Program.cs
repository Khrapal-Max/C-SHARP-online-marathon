using System;
using System.Collections.Generic;
//Define a class IListExtensions with an extension method IncreaseWith(…) that takes an instance of a class, that implements the interface list of integers(IList<int>). Method IncreaseWith(…) increases the value of each item by a certain number. The method can access only those elements that are included in the interface IList.
//   Define a class IEnumerableExtensions with, an extension method ToString() that implements  IEnumerable from generic type T. 
//ToString() loops through a collection and converts a sequence of elements (list of integers) to a meaningful string (items separated with ', ' and surrounded with '[' and ']').
//Use IncreaseWith() and ToString() extention methods in such a way:
namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.ToString<int>());
            numbers.IncreaseWith(5);
            Console.WriteLine(numbers.ToString<int>());            
        }
    }
    public static class IListExtensions
    {
        public static void IncreaseWith(this IList<int> list, int number)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var temp = list[i];
                list.Remove(list[i]);
                list.Insert(i, temp + number);
            }
        }
    }
    public static class IEnumerableExtensions
    {
        public static string ToString<T>(this IEnumerable<T> list)
        {
            return $"[{string.Join(", ", list)}]";
        }
    }
}
