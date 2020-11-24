using System;
using System.Threading;
//Please create class MyProgram.
//Create method Counter that takes one parameter of int type.
//This method should have two threads. 
//One of them calculates the factorial of Counter's argument (n! = 1 * 2 * ... * (n - 1) * n).
//The second thread calculates the appropriate number of Fibonaci sequence (fibo(0) = 0, fibo(1) = 1, ... fibo(n) = fibo(n - 1) + fibo(n - 2)).
//Please implement the additional methods.
//Method Counter should display two messages:
//"Factorial is: <factorial>"
//"Fibbonaci number is: <fibo>".
//The sequence of outputs metters.
//Example:
//Input: MyProgram.Counter(4);
//Output:
//Factorial is: 24
//Fibbonaci number is: 3
namespace Task04
{
    class MyProgram
    {
        public static void Counter(int number)
        {
            int result = 0;
            Thread factorial = new Thread(() => { result = Factorial(number); });
            factorial.Start();
            factorial.Join();
            Console.WriteLine($"Factorial is: {result}");
            Thread fibo = new Thread(() => { result = Fibbonaci(number); });
            fibo.Start();
            fibo.Join();
            Console.WriteLine($"Fibbonaci number is: {result}");
        }
        public static int Factorial(int number)
        {
            #region
            //if (number == 0)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return number * Factorial(number - 1);
            //}
            #endregion
            return number == 0 ? 1 : number * Factorial(number - 1);
        }
        public static int Fibbonaci(int number)
        {
            return number == 0 ? 0 : number == 1 ? 1 : Fibbonaci(number - 1) + Fibbonaci(number - 2);
            #region
            //int a = 0;
            //int b = 1;
            //int tmp;

            //for (int i = 0; i < number; i++)
            //{
            //    tmp = a;
            //    a = b;
            //    b += tmp;
            //}
            //return a;
            #endregion
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyProgram();
            MyProgram.Counter(4);
            Console.WriteLine("Hello World!");
        }
    }
}
