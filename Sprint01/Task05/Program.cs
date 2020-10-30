using System;
//Please, make refactoring of the code:
//      We know that adult  doesn't have childIDNumber 
//      child doesn't have passportNumber.
//      Create a public constructor in each class to initialize all their fields (make the first parameter of type int and the second one for name initialization).
//      Accessibility of the fields should be the least possible, but the same in all assemblies.
//      Add ToString() method to Child and Adult classes that will return a string in the format: "name document_number"

namespace Task05
{
    public class Person
    {
        protected int yearOfBirth;
        protected string name;
        protected string healthInfo;

        public Person(int yearOfBirth, string name, string healthInfo)
        {
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }
        internal virtual string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
    }

    public class Child : Person
    {
        private string childIDNumber;

        public Child(int yearOfBirth, string name, string healthInfo, string childIDNumber) : base(yearOfBirth, name, healthInfo)
        {
            this.childIDNumber = childIDNumber;
        }

        internal override string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
        public override string ToString()
        {
            return name + " " + childIDNumber;
        }
    }

    public class Adult : Person
    {        
        private string passportNumber;

        public Adult(int yearOfBirth, string name, string healthInfo, string passportNumber) : base(yearOfBirth, name, healthInfo)
        {
            this.passportNumber = passportNumber;
        }

        internal override string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
        public override string ToString()
        {
            return name + " " + passportNumber;
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
