using System;
using System.Threading.Tasks;
/*Suppose we have a class named Calc which has a method Seq
generating n-th member of a certain number sequence (starting from 1).

Define a class named CalcAsync.In this class:

Write an asynchronous static method TaskPrintSeqAsync taking integer parameter n,
that prints out the following:
"Seq[X] = Y", where X is the value of input parameter n, Y is n-th member of the sequence.
Use Task as return type

Implement an extention method named PrintStatusIfChanged
which takes, as parameters, a task along with its previous status,
prints out the status if it was changed, and updates the old one (given by the parameter).

Implement an extention method named TrackStatus which takes, as a parameter, a task,
and continuously checks a status of the task, and prints out its status if changed.*/
namespace Task02
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
        public static async Task TaskPrintSeqAsync(int n) => await Task.Run(() => Console.WriteLine($"Seq[{n}] = {Calc.Seq(n)}"));
        public static void PrintStatusIfChanged(this Task task, ref TaskStatus previosTaskStatus)
        {
            if (task.Status > previosTaskStatus)
            {
                previosTaskStatus = task.Status;
                Console.WriteLine(task.Status);
            }

        }
        public static void TrackStatus(this Task task)
        {
            TaskStatus ts = TaskStatus.Created;
            while (ts != TaskStatus.RanToCompletion)
            {
                task.PrintStatusIfChanged(ref ts);
            } 
        }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            Task  t =  CalcAsync.TaskPrintSeqAsync(35);            
            t.TrackStatus();
            await t;
        }
    }
}
//public static class CalcAsync
//{
//    public static async Task TaskPrintSeqAsync(int n)
//    {
//        await Task.Run(() => Console.WriteLine($"Seq[{n}] = {Calc.Seq(n)}"));
//    }
//    public static void PrintStatusIfChanged(this Task task, object previosTaskStatus)
//    {
//        if (task.Status != (TaskStatus)previosTaskStatus)
//        {
//            Console.WriteLine(task.Status);
//        }
//    }
//    public static void TrackStatus(this Task task)
//    {
//        Console.WriteLine(task.Status);
//        while (!task.IsCompleted)
//        {
//            task.PrintStatusIfChanged(task.Status);
//        }
//    }
//}

#region
//using System.Threading.Tasks;
//public static class CalcAsync
//{
//    public static async Task TaskPrintSeqAsync(int n) => await Task.Run(() => Console.WriteLine($"Seq[{n}] = {Calc.Seq(n)}"));
//    public static void PrintStatusIfChanged(this Task task, object previosTaskStatus)
//    {
//        task.Wait();
//        if (task.Status != (TaskStatus)previosTaskStatus)
//        {
//            Console.WriteLine(task.Status);
//        }
//    }
//    public static void TrackStatus(this Task task)
//    {
//        Console.WriteLine(task.Status);
//        task.PrintStatusIfChanged(task.Status);
//    }
//}
#endregion


