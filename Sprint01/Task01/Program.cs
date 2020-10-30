using System;

//Please, create MyAccessModifiers class with next members:
//int field birthYear is unavailable anywhere except this class
//string field personalInfo that is accessible within descendants of this class
//string field IdNumber that is accessible only within descendants in the current assembly
//constructor should be available from everywhere in the program and accept int, string for idNumber, string for personalInfo parameters to initialize three fields mentioned above.
//int property Age which returns the difference between the current year and birthYear and can be accessed everywhere, but only for reading
//common for all instances of the class byte field averageMiddleAge with default value 50
//string property Name accessible anywhere in the current assembly
//string property NickName that can be read anywhere in the program and set only in the current assembly
//method HasLivedHalfOfLife available only for descendants of the class in other assemblies and for all in the current.
//overload operator ==. The operator returns true if name, age, and personalInfo  of objects are equal

namespace Task01
{
    public class MyAccessModifiers
    {
        public static byte averageMiddleAge = 50;
        private int birthYear;
        protected string personalInfo;
        private protected string IdNumber;

        public int Age => DateTime.Now.Year - birthYear;
        internal string Name { get; set; }
        public string NickName { get; internal set; }
        public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            IdNumber = idNumber;
            this.personalInfo = personalInfo;
        }
        protected internal void HasLivedHalfOfLife() { }

        public override bool Equals(object obj)
        {
            return obj is MyAccessModifiers modifiers &&
                   birthYear == modifiers.birthYear &&
                   personalInfo == modifiers.personalInfo &&
                   IdNumber == modifiers.IdNumber &&
                   Age == modifiers.Age &&
                   Name == modifiers.Name;
        }

        public override int GetHashCode()
             => HashCode.Combine(birthYear, IdNumber, personalInfo, Age, Name, NickName);

        public static bool operator ==(MyAccessModifiers left, MyAccessModifiers right)
        {
            return left.Name == right.Name
                && left.Age == right.Age
                && left.personalInfo == right.personalInfo;
        }
        public static bool operator !=(MyAccessModifiers left, MyAccessModifiers right)
        {
            return !(left == right);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

