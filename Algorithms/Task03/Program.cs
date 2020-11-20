using System;
//Your task is  to write a  static method IsValidName() within the class ValidNameSolver. The method determines whether a given as parameter name is valid or not. Return True if the name is valid, False otherwise.
//You are free in your realization of this task. You may define enum, classes and methods as you consider. But note, that one of these additional methods must be written according to iterator pattern. 

//To continue with this task, keep in mind the following definitions:

//A term is either an initials or word.
//initials = 1 character
//words = 2+ characters (no dots allowed)
//You have to follow next rules

//Both initials and words must be capitalized.

//Initials must end with a dot.

//A name must be either 2 or 3 terms long.

//If the name is 3 words long, you can expand the first and middle name or expand the first name only. You cannot keep the first name as an initial and expand the middle name only.

//The last name must be a word (not an initial).


//A valid name is a name written in one of the following ways:

//H.Wells
//H.G.Wells
//Herbert G. Wells
//Herbert George Wells
//The following names are invalid:

//Herbert or Wells (single names not allowed)
//H Wells or H. G Wells (initials must end with dot)
//h.Wells or H. wells or h. g. Wells (incorrect capitalization)
//H.George Wells(middle name expanded, while first still left as initial)
//H.G.W. (last name is not a word)
//Herb.G.Wells(dot only allowed after initial, not word)



//Answer: (penalty regime: 0 %)
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
