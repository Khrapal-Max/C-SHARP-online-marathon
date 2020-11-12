using System;
using System.Collections.Generic;
using System.Linq;
//Create a ListDictionaryCompare() method of the MyUtils class to compare the contents of a List of strings and the values of a Dictionary. These collections must be passed as parameters of the method.

//      For example, for a given list [aa, bb, aa, cc] and dictionary {1=cc, 2=bb, 3=cc, 4=aa, 5=cc }
//you should get true.

//      For a given list [aa, bb, aa, cc, ddd] and dictionary {1=cc, 2=bb, 3=cc, 4=aa, 5=cc }
//you should get false

//      For a given list [aa, bb, aa, cc] and dictionary {1=cc, 2=bb, 3=cc, 4=aa, 5=cc, 6=ddd }
//you should get false

//true - если все значения листа есть в библиотеке


namespace Level02Task01
{
    public class MyUtils
    {
        public bool ListDictionaryCompare(List<string> words, Dictionary<string, string> dictionary)
        {
            if (words.Equals(null) && dictionary.Equals(null))
                return false;
            else
                return words.All(x => dictionary.Values.Distinct().Contains(x)) && dictionary.Values.All(y => words.Distinct().Contains(y));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region
            MyUtils myUtils = new MyUtils();
            List<string> words = new List<string>() { "aa", "bb", "aa", "cc" };
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //dictionary.Add("1", "cc");
            //dictionary.Add("2", "bb");
            //dictionary.Add("3", "cc");
            //dictionary.Add("4", "aa");
            //dictionary.Add("5", "cc");
            Console.WriteLine(myUtils.ListDictionaryCompare(words, dictionary));
            #endregion

            #region
            List<string> words2 = new List<string>() { "aa", "bb", "aa", "cc", "ddd" };
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            dictionary2.Add("1", "cc");
            dictionary2.Add("2", "bb");
            dictionary2.Add("3", "cc");
            dictionary2.Add("4", "aa");
            dictionary2.Add("5", "cc");
            Console.WriteLine(myUtils.ListDictionaryCompare(words2, dictionary2));
            #endregion

            #region
            List<string> words3 = new List<string>() { "aa", "bb", "aa", "cc"};
            Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
            dictionary3.Add("1", "cc");
            dictionary3.Add("2", "bb");
            dictionary3.Add("3", "cc");
            dictionary3.Add("4", "aa");
            dictionary3.Add("5", "cc");
            dictionary3.Add("6", "ddd");
            Console.WriteLine(myUtils.ListDictionaryCompare(words3, dictionary3));
            #endregion


            Console.WriteLine("Hello World!");
        }        
    }
}
