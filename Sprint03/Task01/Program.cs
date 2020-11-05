using System;
//Create a program that can be used for calculation of 4 arithmetic operations (+, -, *, /) according to tasks:
//1) declare a delegate CalcDelegate referring to a function Calc with three parameters (two numbers and one - operation sign) and a numerical result;
//2) define a class CalcProgram and within this class:
//2.1) define a static function Calc for computation with the same signature as the delegate. Note: in case of denominator = 0, the function returns 0.
//2.2) create a delegate's object funcCalc and pass the function Calc as an argument.
namespace Task01
{
    public delegate int CalcDelegate(int first, int second, char sing);

    public class CalcProgram
    {
        CalcDelegate funcCalc = new CalcDelegate(Calc);
        public static int Calc(int first, int second, char sing)
        {
            int res = 0;
            switch (sing)
            {
                case '+':
                    res = first + second;
                    break;
                case '-':
                    res = first - second;
                    break;
                case '*':
                    res = first * second;
                    break;
                case '/':
                    res = second <= 0 ? res : first / second;
                    break;                    
            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
