using System;
//Define a class StringExtensions with an extension method WordCount(…) for class String that counts the number of words in a given string. 
//Note. Try to use string.Split() method and pass array of delimiters as the first parameter. 
namespace Task02
{
    public static class StringExtensions
    {
        public static int WordCount(this string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return 0;
            return word.Split(new char[] { ' ', '!', '.', '?', ':', ';', ',', '-' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string a = ". ";
            int c = a.WordCount();
            Console.WriteLine(c);
        }
    }
}
