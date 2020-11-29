using System;
using System.Threading.Tasks;
/*Suppose we have a class named Calc which has a method Seq
generating n-th member of a certain number sequence (starting from 1).

Define a class named CalcAsync.In this class:

Write an asynchronous static method SeqAsync taking integer parameter n,
that returns n-th member of the sequence.
Use Task<> as a return type.

Write an asynchronous static method PrintSeqElementsConsequentlyAsync
taking integer parameter quant,
which calls SeqAsync method for each integer number i from 1 to quant
and prints the result as follows:
"Seq[X] = Y", where X is i, Y is the i-th sequence member.

Write an asynchronous static method PrintSeqElementscaInParallelAsync
taking integer parameter quant,
which does the same as previous one, except of the way of calling SeqAsync method.
Each call of this method should be performed so that
it would run in parallel, not waiting for previous one.
After the last member is received, the results should be printed as described before.

Write the auxiliary method GetSeqAsyncTasks that will be used in the previous one.
This method should take integer parameter n and return an array of Task<> objects.
Each of those tasks should be responsible for geting one sequence member.*/
namespace Task03
{
    public static class Calc
    {
        public static int Seq(int n)
        {
            return n + 1;
        }
    }
    public static class CalcAsync
    {
        public static async Task<int> SeqAsync(int n) => await Task.Run(() => Calc.Seq(n));
        public static async void PrintSeqElementsConsequentlyAsync(int quant)
        {
            for (int i = 1; i <= quant; i++)
            {
                Console.WriteLine($"Seq[{i}] = {await SeqAsync(i)}");
            }
        }
        public static async void PrintSeqElementsInParallelAsync(int quant)
        {
            var task = GetSeqAsyncTasks(quant);
            for (int i = 0; i < task.Length; i++)
            {
                await Task.Run(() => Console.WriteLine($"Seq[{i + 1}] = {task[i].Result}"));
            }
        }
        public static Task<int>[] GetSeqAsyncTasks(int n)
        {
            Task<int>[] tasks = new Task<int>[n];
            Parallel.For(0, tasks.Length, i => tasks[i] = Task.Run(() => Calc.Seq(i + 1)));
            return tasks;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CalcAsync.PrintSeqElementsInParallelAsync(5);
            Console.WriteLine("Hello World!");
        }
    }
}

