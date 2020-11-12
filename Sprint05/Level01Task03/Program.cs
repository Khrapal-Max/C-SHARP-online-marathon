using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
//We have the next collection:  

//Dictionary<string, string> persons = new Dictionary<string, string>();
//{
//    persons.Add("id11111", "Admin");
//    persons.Add("id12345", "User1");
//    persons.Add("id98765", "User2");
//    persons.Add("id56743", "User3");
//    persons.Add("id73920", "User4");
//}
//1) In class MyProgram please create a method that should take a collection of arguments SearchKeys(Dictionary<string, string> persons) in which print all keys from this collection
//2) method that should take a collection of arguments SearchValues(Dictionary<string, string> persons) in which print all values from this collection
//3) and method that should take a collection of arguments SearchAdmin(Dictionary<string, string> persons) in which search value "Admin" and print information in format Key + " " + Value 
namespace Level01Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<string, string> persons = new Dictionary<string, string>();
            {
                persons.Add("id11111", "Admin");
                persons.Add("id12345", "User1");
                persons.Add("id98765", "User2");
                persons.Add("id56743", "User3");
                persons.Add("id73920", "User4");
            }
            SearchKeys(persons);
            SearchValues(persons);
            SearchAdmin(persons);
        }
        public static void SearchKeys(Dictionary<string, string> persons) => persons.Select(x => x.Key).ToList().ForEach(x => Console.WriteLine(x));
        public static void SearchValues(Dictionary<string, string> persons) => persons.Select(x => x.Value).ToList().ForEach(x => Console.WriteLine(x));
        public static void SearchAdmin(Dictionary<string, string> persons) => persons.Where(x => x.Value == "Admin").ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
    }
}
