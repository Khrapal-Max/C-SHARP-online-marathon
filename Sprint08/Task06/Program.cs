using System;
using System.Collections.Generic;
using System.Threading;
//We have a shop. Due to the situation with coronavirus, there are limitations on the number of buyers that are allowed to be in the shop simultaneously.

//     There are allowed 10 users maximum in the shop.

//     Create a class Buyer. Objects of this class must do their shopping in separate threads.

//     Buyer must be derived from PersonInTheShop class. Don 't create PersonInTheShop, it already exists in the same namespace.

//     Implement constructor for Buyer which takes a string argument - thread name. Use this name to set the name of a new thread that will be started. Start the thread in the constructor.

//     Every buyer does shopping in its own thread. Four methods of a base class should be called for every shopping: Enter(), SelectGroceries(), Pay(), Leave().


namespace Task06
{
    public class PersonInTheShop
    {
        public void Enter() { }
        public void SelectGroceries() { }
        public void Pay() { }
        public void Leave() { }

    }
    public class Buyer : PersonInTheShop
    {
        private static Semaphore semaphore = new Semaphore(10, 10);
        private Thread threadName;
        public Buyer(string buyersName)
        {
            threadName = new Thread(CheckWithBuyers)
            {
                Name = buyersName
            };
            threadName.Start();
        }
        public void CheckWithBuyers()
        {
            semaphore.WaitOne();
            Enter();
            SelectGroceries();
            Pay();
            Leave();
            semaphore.Release();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Buyer buyer1 = new Buyer("1");
            Buyer buyer2 = new Buyer("2");
            Buyer buyer3 = new Buyer("3");
            Buyer buyer4 = new Buyer("4");
            Buyer buyer5 = new Buyer("5");
            Buyer buyer6 = new Buyer("6");
            Buyer buyer7 = new Buyer("7");
            Buyer buyer8 = new Buyer("8");
            Buyer buyer9 = new Buyer("9");
            Buyer buyer10 = new Buyer("10");
            Buyer buyer11 = new Buyer("11");
            Buyer buyer12 = new Buyer("12");
            Buyer buyer13 = new Buyer("13");
            Buyer buyer14 = new Buyer("14");

            Console.WriteLine("Hello World!");
        }
    }
}
#region
//public class Buyer : PersonInTheShop
//{
//    private int countBuyers;
//    public List<Buyer> buyers;
//    public int CountBuyers
//    {
//        get => countBuyers;
//        set => countBuyers = buyers.Count;
//    }
//    public Buyer(string threadName)
//    {
//        countBuyers <= 10 ? buyers.Add(this) : ;
//        Thread thread = new Thread(Enter);
//        thread.Name = threadName;
//        thread.Start();
//    }
//}
#endregion
