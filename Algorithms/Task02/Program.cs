using System;
//You know already what number can be called 'palindrome'. 

//A number may not be a palindrome, but its heritor can be. A number's direct child is created by summing each pair of adjacent digits to create the digits of the next number.

//For instance, 123312 is not a palindrome, but its next child 363 is, where: 3 = 1 + 2; 6 = 3 + 3; 3 = 1 + 2.

//Within the class PalindromeSolver :

//- create a static method IsPalindromeHeritor() that takes long integer parameter (given number) and returns True if the number itself is a palindrome or any of its heritors down to 2 digits is a palindrome;

//-create a static method IsPalindrome() that takes generics IEnumerable (the sequence of chars that represents given number). This method returns True if the given number is palindrome and False in opposite case. This method is called from the method IsPalindromeHeritor() ;

//-create a static method GetHeritor() that takes generics IEnumerable (the sequence of chars that represents given number) and returns a heritor (in a string representation) to the given number.  This method is called from the method IsPalindromeHeritor(). 

//Examples
//IsPalindromeHeritor(11211203) ➞ False
//// 11211203 ➞ 2333 ➞ 56
//IsPalindromeHeritor(31001120) ➞ True
//// 31001120 ➞ 4022 ➞ 44
//IsPalindromeHeritor(8677) ➞ True
//// 8677 ➞ 1414 ➞ 55
//IsPalindromeHeritor(33) ➞ True
//// Number itself is a palindrome.
//Notes
//Numbers will always have an even number of digits.
//A 1-digit number is trivially a palindrome.
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
