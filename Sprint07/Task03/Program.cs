using System;
using System.Collections.Generic;
using System.Linq;
//Please, create a method ProductWithCondition that takes a list of integers as a parameter and returns a product of elements that satisfy a condition that as passed as a second parameter.

//The second parameter should be a Func that takes an integer as a parameter and returns bool.

//If the first parameter contains 0 elements the method must return 1.

//(You don't need to verify on null parameter values. Assume that parameters will always be not null)
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() ;
            Func<int, bool> predicate = i => i % 2 != 0;
            Console.WriteLine($"{ProductWithCondition(list, predicate)}");

            Console.WriteLine("Hello World!");
        }
        public static int ProductWithCondition(List<int> list, Func<int, bool> predicate)
        {
            var result = list.Where(predicate);
            if(result.Count() == 0)
            {
                return 1;
            }
            return result.Aggregate((x, y) => x * y);
        }
    }
}
