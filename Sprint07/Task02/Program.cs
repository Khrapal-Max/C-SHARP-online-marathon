using System;
using System.Linq;
//Please, implement EvaluateAggregate method that takes 

//     an array of doubles as the first parameter,

//     a delegate that defines an aggregate behavior as the second,

//     a delegate that defines a condition for the index as the third parameter.

//The method should return a result of an aggregate operation for the elements with indexes that satisfy the condition set by the third parameter

//(You don't need to verify on null parameter values. Assume that parameters will always be not null
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrey = new double[] { 1.25, 1.25, 1.5, 1.75 };
            Func<double, double, double> addition = (x, i) => x + i;
            Func<double, int, bool> second = (x, i) => i % 2 != 0;
            Func<double, int, bool> first = (x, i) => i % 2 == 0;
            Console.WriteLine($"{EvaluateAggregate(arrey, addition, first)}");
            Console.WriteLine($"{EvaluateAggregate(arrey, addition, second)}");
            Console.WriteLine("Hello World!");
        }
        public static double EvaluateAggregate(double[] inputData, Func<double, double, double> aggregate, Func<double, int, bool> predicate)
        {       
            return inputData.Where(predicate).Aggregate(aggregate);
        }       
    }
}
