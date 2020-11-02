using System;
//Create abstract class Car and two derived classes: SportCar and Lory.
//Class Car should have the next fields: internal string mark, internal int prodYear.
//Class SportCar should have the next fields: internal string mark, internal int prodYear, private int maxSpeed.
//Class Lory should have internal string mark, internal int prodYear and private double loadCapacity.
//Create also appropriable constructors that allow create class instances with all the fields.
//Every class should have public void method ShowInfo().
//For class Car this method should display message:
//“Mark: < mark >,
//Producted in < prodYear >”
//For SportCar this method should display message:
//“Mark: < mark >,
//Producted in < prodYear >
//Maximum speed is < maxSpeed >”
//For Lory this method should display message:
//“Mark: < mark >,
//Producted in < prodYear >
//The load capacity is <loadCapacity>”
//Please organize the code optimally.
//namespace Task02
namespace Task02
{
    abstract class Car
    {
        internal string mark;
        internal int prodYear;

        protected Car(string mark, int prodYear)
        {
            this.mark = mark;
            this.prodYear = prodYear;
        }

        public virtual void ShowInfo() 
        {
            Console.WriteLine($"Mark: {mark},\n Producted in {prodYear}");
        }
    }
    class SportCar : Car
    {
        private int maxSpeed;

        public SportCar(string mark, int prodYear, int maxSpeed) : base (mark, prodYear)
        {
            this.maxSpeed = maxSpeed;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Maximum speed is {maxSpeed}");
        }
    }
    class Lory : Car
    {      
        private double loadCapacity;

        public Lory(string mark, int prodYear, double loadCapacity) : base(mark, prodYear)
        {
            this.loadCapacity = loadCapacity;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"The load capacity is {loadCapacity }");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
