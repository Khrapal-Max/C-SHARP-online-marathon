using System;
using System.Collections;

namespace ConsoleApp1
{
    public class CoffeeColection : IEnumerable
    {
        private CoffeeEnumenator enumenator;
        public CoffeeColection()
        {
            enumenator = new CoffeeEnumenator();
        }
        public IEnumerator GetEnumerator()
        {
            return enumenator;
        }
    }
    public class CoffeeEnumenator : IEnumerator
    {
        string[] beheviors = new string[] { "1", "2", "3" };
        int currentIndex = -1;
        public object Current => beheviors[currentIndex];
        public bool MoveNext()
        {
            currentIndex++;
            if(currentIndex < beheviors.Length)
            {
                return true;
            }
            return false;
        }
        public void Reset()
        {
            currentIndex = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in new CoffeeColection())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
