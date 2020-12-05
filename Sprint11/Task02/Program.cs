using System;
using System.Reflection;
//Within the class ReflectMethod you have to:
//1) define the public static class Methods with three public static methods: Hello(), Welcome() and Bye(). Each of them takes a string parameter and provides the console output of formatted string according to its name:
//("Hello:parameter={0}", parameter)
//("Welcome:parameter={0}", parameter)
//("Bye:parameter={0}", parameter)
//2) define the public static method InvokeMethod() which takes the string array as parameter. 
//The logic of the method involves:
//-to form a collection of methods from the class Methods, 
//-to iterate over this collection by the method name,
//- to invoke the method and pass it parameters from the array one by one.
//The call of InvokeMethod() provides the output as follows:
namespace Task02
{
    class ReflectMethod
    {
        public static class Methods
        {
            public static void Hello(string parameter) => Console.WriteLine($"Hello:parameter={parameter}");
            public static void Welcome(string parameter) => Console.WriteLine($"Welcome:parameter={parameter}");
            public static void Bye(string parameter) => Console.WriteLine($"Bye:parameter={parameter}");

        }
        public static void InvokeMethod(string[] parameters)
        {
            Type type = typeof(Methods);
            foreach (MethodInfo info in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
            {
                foreach (var item in parameters)
                {
                    info.Invoke(type, new object[] { item });
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = { "Jhon", "Elly" };
            ReflectMethod.InvokeMethod(parameters);
            Console.WriteLine("Hello World!");
        }
    }
}
