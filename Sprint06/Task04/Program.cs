using System;
using System.Collections;
using System.Collections.Generic;
//Within the class, ShowPowerRange create a static method PowerRanger() that takes in integer degree, start, finish. 

//The method returns all the numbers from the range [start, finish] (inclusive and finish > 0 and start > 0) that are equal to the degree-th power of any integer.

//In the case start > finish, or start < 0, or finish < 0 the method returns 0.

//The method involves yielding the intermediate result on each iteration.


//For example, when calling the method PowerRanger():

//t6_7_1
//Output:
namespace Task04
{
    class ShowPowerRange
    {
        public static IEnumerable<double> PowerRanger(int degree, int start, int finish)
        {
            if (start > finish || start < 0 || finish < 0)
            {
                yield return 0;
            }
            else if (degree <= 0)
            {
                yield return 1;
            }
            else
            {
                double count = 0;
                double number = 0;
                while (number < finish)
                {
                    number = Math.Pow(count, degree);
                    if (number >= start && number <= finish)
                    {
                        yield return number;
                    }
                    count++;
                }
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int item in ShowPowerRange.PowerRanger(3, 1, 200))
            {
                Console.WriteLine(item);
            }
            #region
            //Console.WriteLine("start > finish");
            //foreach (int item in ShowPowerRange.PowerRanger(3, 201, 200))
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("start < 0");
            //foreach (int item in ShowPowerRange.PowerRanger(3, -1, 200))
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("finish < 0");
            //foreach (int item in ShowPowerRange.PowerRanger(3, 1, -200))
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            Console.WriteLine("I default1 Result 1, 8, 27, 64, 125");
            //1 = 1^3
            //8 = 2^3
            //27 = 3^3
            //64 = 4^3
            //125 = 5^3
            Console.WriteLine("Hello World!");
        }
    }
}
