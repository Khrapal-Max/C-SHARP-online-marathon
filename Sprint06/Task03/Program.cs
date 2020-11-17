using System;
using System.Collections;
using System.Collections.Generic;
//Inside a class ShowPower define a static method SuperPower(). SuperPower() has two integer input parameters: number and degree. The method will  calculate the power of a given number according to degree parameter.

//Note: Don 't use Pow().

//The method involves to yield the intermediate result of the calculation on the each iteration.

//For example, when calling the method SuperPower():

//t6_3

//Output:
namespace Task03
{
    class ShowPower
    {
        public static IEnumerable<float> SuperPower(int number, int degree)
        {
            if (degree == 0)
            {
                yield return 1F;
            }
            else if (number == 0)
            {
                yield break;
            }
            else
            {
                float result = number;
                if (degree > 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        yield return i < 1 ? result : result *= number;
                    }
                }
                else
                {
                    for (int i = 0; i < degree * -1; i++)
                    {
                        yield return i < 1 ? result = 1 / (float)number : result /= number;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iterator");
            foreach (float item in ShowPower.SuperPower(3, 4))
            {
                Console.WriteLine(item);                
            }
            Console.WriteLine("Mat");
            Console.WriteLine(Math.Pow(3, 1));
            Console.WriteLine(Math.Pow(3, 2));
            Console.WriteLine(Math.Pow(3, 3));
            Console.WriteLine(Math.Pow(3, 4));
            Console.WriteLine("Iterator");
            foreach (float item in ShowPower.SuperPower(-3, 4))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Mat");
            Console.WriteLine(Math.Pow(-3, 1));
            Console.WriteLine(Math.Pow(-3, 2));
            Console.WriteLine(Math.Pow(-3, 3));
            Console.WriteLine(Math.Pow(-3, 4));
            Console.WriteLine("Iterator");
            foreach (float item in ShowPower.SuperPower(0, -4))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Mat");
            Console.WriteLine(Math.Pow(1, -1));
            Console.WriteLine(Math.Pow(2, -2));
            Console.WriteLine(Math.Pow(0, -3));
            Console.WriteLine(Math.Pow(0, -4));
            Console.WriteLine("Hello World!");
        }
    }
}
