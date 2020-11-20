using System;
using System.Linq;

//Please, create a static method GetWord takes 2 string parameters: 

//         first - initial string with a sequence of words separated by space 

//         second - a word for comparison.

//The method should find the longest word in the first parameter, that is longer than the second parameter if there is one,

//otherwise, the second parameter should be the result of the search.

//The method should return the part of the found word, starting from the first 'a' char. 

//If there isn't 'a' char in the found word, the method should return an empty string.

//(You don't need to verify on null parameter values. Assume that parameters will always be not null)
namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordWithSpace = "AAA BaBBB CC";
            string wordComparison = "DDaaaDD";
            Console.WriteLine(GetWord(wordWithSpace, wordComparison));
            GetWord(wordWithSpace, wordComparison);
            Console.WriteLine("Hello World!");
        }
        public static string GetWord(string input, string seed)
        {
            string word = (input + " " + seed).Split(' ').OrderByDescending(x => x.Length).First();
            return word.Contains('a') ? word.Substring(word.IndexOf('a')) : string.Empty;            
        }
    }
}
