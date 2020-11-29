using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/*Suppose we have a class named Calc which has a method Seq
generating n-th member of a certain number sequence (starting from 1).

Define a class named CalcAsync.In this class:

Write an asynchronous stream called SeqStreamAsync taking integer parameter n,
that returns a collection of n tuples
consisting of a number i (from 1 to n) and i-th member of the sequence.

Write an asynchronous static method PrintStream
taking an asynchronous stream of tuples consisting of 2 integer numbers,
which prints the collection as follows:
"Seq[X] = Y", where X is the first item of a tuple, Y is the second one.*/
namespace Task04
{
    public class Calc
    {
        public static int Seq(int n)
        {
            return n + 1;
        }
    }
    public class CalcAsync //убрать статик
    {
        public async IAsyncEnumerable<(int firstItem, int secondItem)> SeqStreamAsync(int number)
        {
            for (int i = 0; i < number; i++)
            {
                yield return (firstItem: i + 1, secondItem: await Task.Run(() => Calc.Seq(i + 1)));
                //var result = (firstItem: i, secondItem: await Task.Run(() => Calc.Seq(number + 1)));
                //yield return result;
                //yield return await Task.Run(() => (i + 1, Calc.Seq(i + 1)));
            }
        }
        public async void PrintStream(IAsyncEnumerable<(int firstItem, int secondItem)> tuple)
        {
            await foreach (var number in tuple)
            {
                Console.WriteLine($"Seq[{number.firstItem}] = {number.secondItem}");
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        //CalcAsync repo = new CalcAsync();
        //IAsyncEnumerable<(int firstItem, int secondItem)> data = repo.SeqStreamAsync(4);
        //await foreach (var number in data)
        //{
        //    Console.WriteLine($"Seq[{number.firstItem}] = {number.secondItem}");
        //}
        //Console.WriteLine("Hello World!");
    }
    private static (string name, int age) GetTuple((string n, int a) tuple, int x)
    {
        var result = (name: tuple.n, age: tuple.a + x);
        return result;
    }
}

