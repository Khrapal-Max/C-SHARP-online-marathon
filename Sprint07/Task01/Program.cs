using System;
using System.Linq;
//Please, implement the SumOfElementsOddPositions method that returns sum of elements with odd indexes in the array of doubles

//(You don't need to verify on null parameter value. Assume that parameter will always be not null)


namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrey = new double[] { 1.25, 1.25, 1.5, 1.75 };
            Console.WriteLine(EvaluateSumOfElementsOddPositions(arrey));
            Console.WriteLine("Hello World!");
        }
        public static double EvaluateSumOfElementsOddPositions(double[] inputData)
        {
            return inputData.Where((x, i) => i % 2 != 0).Sum();
        }
    }
}
