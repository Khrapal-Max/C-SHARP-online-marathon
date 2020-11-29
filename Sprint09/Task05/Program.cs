using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
/*Suppose we have a class named Calc which has a method Seq
generating n-th member of a certain number sequence (starting from 1).

Define a class named CalcAsync.In this class:

Write an asynchronous static method PrintSpecificSeqElementsAsync
taking an array of integers as a patameter,
which performs a calculation of apropriate sequence member
according to each number in the input array
and prints out the result as follows:
"Seq[X] = Y", where X is a number from input array, Y is the corresponding sequence member.
Each calculation should be performed in a separate task.
After last calculation is performed, the list of found exceptions should be printed.

(The method Seq generates appropriate exception for non-positive input parameter.)*/
namespace Task05
{
    public class Calc
    {
        public static int Seq(int n)
        {
            try
            {
                if (n < 0)
                {
                   
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return n + 1; 
        }
    }
    public class CalcAsync
    {
        public static async void PrintSpecificSeqElementsAsync(int[] array)
        {
            Task t = null;
            var tasks = new List<Task>();
            try
            {
                foreach (var item in array)
                {
                    tasks.Add(Task.Run(() => Console.WriteLine($"Seq[{item}] = {Calc.Seq(item)}")));
                }
                t = Task.WhenAll(tasks);
                await t;
            }
            catch
            {
                foreach (var item in t.Exception.InnerExceptions)
                {
                    Console.WriteLine($"Inner exception: {item.Message}");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 20, 1, -1 };            
            CalcAsync.PrintSpecificSeqElementsAsync(numbers);
            Console.WriteLine("Hello World!");
            //int[] numbers2 = { 5, -3, -4, 19 };
            //CalcAsync.PrintSpecificSeqElementsAsync(numbers);
            //Console.WriteLine("Hello World!");
            //int[] numbers3 = { -3, -5, -12, 0 };
            //CalcAsync.PrintSpecificSeqElementsAsync(numbers);
            //Console.WriteLine("Hello World!");
        }
    }
}
//List<string> tasks = new List<string>();
//Array.Sort(array);
//for (int i = 0; i < array.Length; i++)
//{
//    try
//    {
//        Console.WriteLine($"Seq[{array[i]}] = {await Task.Run(() => Calc.Seq(array[i]))}");
//    }
//    catch (Exception ex)
//    {
//        tasks.Add(ex.Message);
//    }
//}
//tasks.ForEach(x => Console.WriteLine($"Inner exception: {x}"));

//for (int i = 0; i < array.Length; i++)
//{
//    Console.WriteLine($"Seq[{array[i]}]");
//}

//public class CalcAsync
//{
//    public static async void PrintSpecificSeqElementsAsync(int[] array)
//    {
//        Task t = null;
//        var tasks = new List<Task>();
//        try
//        {
//            foreach (var item in array)
//            {
//                tasks.Add(Task.Run(() => Console.WriteLine($"Seq[{item}] = {Calc.Seq(item)}")));
//            }
//            t = Task.WhenAll(tasks);
//            await t;
//        }
//        catch
//        {
//            foreach (var item in t.Exception.InnerExceptions)
//            {
//                Console.WriteLine($"Inner exception: {item.Message}");
//            }
//        }
//    }
//}