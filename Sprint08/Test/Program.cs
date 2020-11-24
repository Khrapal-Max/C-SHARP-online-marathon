using System;
using System.Threading;

namespace Test
{
    class Program
    {
        private static int x; // Закрытая статическая переменная.
        private static object lockObj = new object();// Закрытый обьект-заглушка для оператора lock.
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread newThread = new Thread(CountMethod);
                newThread.Name = "Поток №" + i.ToString();
                newThread.Start();
            }

            Console.ReadLine();
        }
        public static void CountMethod()
        {
            //lock (lockObj) // Блокирование объекта потоком.
            {
                for (x = 1; x < 9; x++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
