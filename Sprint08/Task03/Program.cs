using System;
using System.Threading.Tasks;

namespace Task03
{
    class MyTasks
    {
        public static void Tasks()
        {
            int[] sequence_array = new int[10];
            Task[] tasks1 = new Task[3]
            {
            new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    sequence_array[i] = i * i;
                }
                Console.WriteLine("Calculated!");
            }),
            new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Bye!");
            }),
            new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(sequence_array[i]);
                }
                Console.WriteLine("Bye!");
            })
            };
            foreach (var t in tasks1)
            {
                t.Start();
                t.Wait();
            }
            Console.WriteLine("Main done!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyTasks.Tasks();
            Console.WriteLine("Main done!");
        }
    }
}
