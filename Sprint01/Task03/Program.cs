using System;
//Create class Fraction with private int fields numerator and denominator that can only be initialized on creation or in constructor
//Create a constructor to initialize these values
//Define operators unary and binary + and - 
//Define the ! operator that will return reversed fraction - with numerator as denominator and denominator as numerator
//Define binary  * and / operations.
//All operations should return simplified fractions.
//Define ToString() method which will return string representing Fraction in the format numerator / denominator. 
//Value should be simplified: numerator and denominator divided by the greatest common divisor. 
//if  numerator and denominator are both negative, the fraction should become positive. 
//If only denominator is negative the sign should be outputted before numerator without space.
//Define Equals  method and operators == and !=. Fractions are equal if their simplified versions are equal. 
//(for example, 20/25 isequal to 4/5)
//Define GetHashCode() method with implementation at your choise.
namespace Task03
{
    public class Fraction
    {
        private readonly int numerator, denominator;

        public Fraction(int numerator, int denominator)
        {
            if ((numerator < 0 && denominator < 0) || (numerator > 0 && denominator < 0))
            {
               numerator *= -1;
               denominator *= -1;
            }
            for (int i = numerator > denominator ? numerator : denominator; i > 1; i--)
            {
                if ((numerator % i == 0) && (denominator % i == 0))
                {
                    numerator /= i;
                    denominator /= i;
                    break;
                }
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public static Fraction operator +(Fraction fraction)
        {
            return fraction;
        }
        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction (-fraction.numerator, fraction.denominator);
        }
        public static Fraction operator +(Fraction left, Fraction right)
        {
            return new Fraction((left.numerator * right.denominator) + (right.numerator * left.denominator), left.denominator * right.denominator);
        }
        public static Fraction operator -(Fraction left, Fraction right)
        {
            return new Fraction((left.numerator * right.denominator) - (right.numerator * left.denominator), left.denominator * right.denominator);
        }
        public static Fraction operator !(Fraction fraction)
        {
            return new Fraction(fraction.denominator, fraction.numerator); 
        }
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return new Fraction(left.numerator * right.numerator, left.denominator * right.denominator);
        }
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return new Fraction(left.numerator * right.denominator, left.denominator * right.numerator);
        }
        public static bool operator ==(Fraction left, Fraction right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return numerator + " / " + denominator;
        }
        public override bool Equals(object obj)
        {
            return obj is Fraction fraction &&
                   numerator == fraction.numerator &&
                   denominator == fraction.denominator;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(2, 4);
            Fraction b = new Fraction(4, 8);
            Fraction c = new Fraction(70, 140);
            var res = a + b;
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
