using System;
using System.Collections.Generic;
//Define a static method ListWithPositive that receives the generic List as a parameter. The List will consist of negative and positive elements.
//The method  ListWithPositive uses the FindAll method on the List type. FindAll method receives one integer and returns a boolean. The argument to FindAll will use the anonymous method syntax.
//The predicate in FindAll will use a boolean expression that is evaluated, causing the anonymous function to return true if the argument is positive and less then or equal 10.
//The method  ListWithPositive returns the list of positive elements.
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, -4};            
            var n = ListWithPositive(list);
            foreach (var item in n)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello World!");
        }
        public static List<int> ListWithPositive(List<int> list)
        {
            return list.FindAll(x => x <= 10 && x > 0);
        }
        public class Number
        {

        }
    }   
}
