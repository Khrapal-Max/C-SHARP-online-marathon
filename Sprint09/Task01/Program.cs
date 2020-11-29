using System;
using System.Threading.Tasks;
//Suppose we have a class named Calc which has a method Seq
//generating n-th member of a certain number sequence (starting from 1).

//Define a class named CalcAsync.In this class:

//Write an asynchronous static method PrintSeqAsync taking integer parameter n,
//that prints out the following:
//"Seq[X] = Y", where X is the value of input parameter n, Y is n-th member of the sequence.
//Use void as return type.
namespace Task01
{
    public static class Calc
    {
        public static int Seq(int n)
        {
            Random rnd = new Random(10);
            int value = rnd.Next(0, 10);
            return value;
        }
    }
    public static class CalcAsync
    {
        public static async void  PrintSeqAsync(int n) =>
            Console.WriteLine($"Seq[{n}] = {await Task.Run(() => Calc.Seq(n))}");
    }
    class Program
    {
        static void Main(string[] args)
        {
            CalcAsync.PrintSeqAsync(1);
            CalcAsync.PrintSeqAsync(3);
            CalcAsync.PrintSeqAsync(5);
            CalcAsync.PrintSeqAsync(7);
            CalcAsync.PrintSeqAsync(9);
            CalcAsync.PrintSeqAsync(11);
            Console.WriteLine("Hello World!");
        }
    }
}


