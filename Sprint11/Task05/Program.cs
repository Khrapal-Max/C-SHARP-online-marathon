using System;
using System.Reflection;
using System.Linq;
//Within the class ReflectFullClass define a static method WriteAllInClass(). The method will take one parameter of Type type (f.e. class). 

//The method outputs a greeting with the class and allows it to iterate through the class and output the names of all custom members of the class (fields, properties, methods), interfaces, and the total quantity of every member and interface.

//The probable result of invoking:
namespace Task05
{
    class ReflectFullClass
    {
        public static void WriteAllInClass(Type type)
        {
            Console.WriteLine($"Hello, {type.Name}!");

            Console.WriteLine($"There are {type.GetFields().Length} fields in MyClass:");
            type.GetFields().ToList().ForEach(x => Console.Write($"{x.Name}, "));

            Console.WriteLine($"\nThere are {type.GetProperties().Length} properties in MyClass:");
            type.GetProperties().ToList().ForEach(x => Console.Write($"{x.Name}, "));

            Console.WriteLine($"\nThere are {type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Where(x => !x.IsSpecialName).Count()} methods in MyClass:");
            type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Where(x => !x.IsSpecialName).ToList().ForEach(x => Console.Write($"{x.Name}, "));

            Console.WriteLine($"\nThere are {type.GetNestedTypes().Where(x => x.IsInterface).ToList().Count} interfaces in MyClass:");
            type.GetNestedTypes().Where(x => x.IsInterface).ToList().ForEach(x => Console.Write($"{x.Name}, "));
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
