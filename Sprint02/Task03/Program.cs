using System;
//Create three classes: Science, Mathematics and Physics. Organize inheritance in the correct way.
//Create method Awards() so that the next code
//Gives the next output
//Keep your code as optimized as possible.
//Tip: use virtual method.
namespace Task03
{
    public class Science
    {
        public virtual void Awards() 
        {
            Console.WriteLine("We can obtain The Nobel Prize");
        }
    }
    public class Mathematics : Science
    {
        public override void Awards()
        {
            Console.WriteLine("We don't need any awards, but we still can obtain The Abel Prize that nobody else can!");
        }
    }   
    public class Physics : Science { }  
    class Program
    {
        static void Main(string[] args)
        {
            Science science1 = new Mathematics();
            Science science2 = new Physics();
            Science science3 = new Science();
            science1.Awards();
            science2.Awards();
            science3.Awards();
            //We don't need any awards, but we still can obtain The Abel Prize that nobody else can!
            //We can obtain The Nobel Prize
            Console.ReadLine();
        }
    }
}
