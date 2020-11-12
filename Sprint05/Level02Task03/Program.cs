using System;
using System.Collections.Generic;
using System.Linq;
//Implement the ReverseNotebook() method that creates a new dictionary with name as key and list of phones as value.  The method receives a dictionary  with phone as key and name as value.

//For example, for a given dictionary {0967654321=Petro, 0677654321=Petro, 0501234567=Ivan, 0970011223=Stepan, 0631234567=Ivan} 
//you should get {Ivan=[0501234567, 0631234567], Petro =[0967654321, 0677654321], Stepan =[0970011223]}.

//The method should work with entry notebook containing empty or null names without throwing exceptions. Use empty string as a key for null names.
namespace Level02Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonesToNames = new Dictionary<string, string>();
            phonesToNames.Add("0967654321", "Petro");
            phonesToNames.Add("0677654321", "Petro");
            phonesToNames.Add("0501234567", "Ivan");
            phonesToNames.Add("0970011223", "Stepan");
            phonesToNames.Add("0631234567", "Ivan");
            phonesToNames.Add("063123456d", " ");
            phonesToNames.Add("063123456d", " ");

            ReverseNotebook(phonesToNames);

            Console.WriteLine("Hello World!");
        }
        public static Dictionary<string, List<string>> ReverseNotebook(Dictionary<string, string> phonesToNames)
        {
            ILookup<string, string> lookup = phonesToNames.ToLookup(x => x.Value ?? string.Empty, x => x.Key);
            return lookup.ToDictionary(x => x.Key.ToString(), x => x.ToList());
        }
    }
}
