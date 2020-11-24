using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

//We have class MainThreadProgram. Please create three methods: Calculator, Product and Sum.

//Method Sum() should ask user to enter 5 numbers in form “Enter the 1st number :”, “Enter the 2nd number :” etc.and calculate their sum. After that it should output the message “Sum is <sum>”. 

//Method Product() should generate a List of 10 consequent integer numbers from 1 to 10 and calculate their product. Then it should wait for 10 seconds. After that it should output the message “Product is <product>”. 

//The Calculator() method should create two threads: productThread and sumThread, and call the Product and Sum methods in appropriate threads. This method should return a tuple of two threads: (sumThread, productThread).
namespace Task02
{
    class MainThreadProgram
    {
        public static (Thread, Thread) Calculator()
        {
            Thread productThread = new Thread(Product);
            productThread.Start();
            Thread sumThread = new Thread(Sum);
            sumThread.Start();
            return (sumThread, productThread);
        }
        public static void Product()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Thread.Sleep(10000);
            Console.WriteLine($"Product is: {list.Aggregate((x, y) => x *= y)}");
        }
        public static void Sum()
        {
            int sum = 0;
            int count = 0;
            while (++count <= 5)
            {
                Console.WriteLine($"Enter the {count}{GetEnding(count)} number:");
                int number = Convert.ToInt32(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine($"Sum is: {sum}");
        }
        public static string GetEnding(int number) => number switch
        {
            0 => string.Empty,
            1 => "st",
            2 => "nd",
            _ => "th"
        };
    }
    class Program
    {
        static void Main(string[] args)
        {
            MainThreadProgram.Sum();
            MainThreadProgram.Product();
            Console.WriteLine("Hello World!");
        }
    }
}
