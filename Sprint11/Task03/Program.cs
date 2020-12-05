using System;
using System.Reflection;
using static Task03.ReflectProperties;
//Within the class ReflectProperties you have to:
//1) create public class TestProperties with four properties:
//- public string FirstName;
//- internal string LastName;
//- protected int Age;
//- private string PhoneNumber.
//2) define a static method WriteProperties() that contains logic:
//-form the collection of the properties of TestProperties class;
//-iterate through the collection;
//-provide the console output of the name, type, read/write ability, and accessibility level of every property.
//The invoke of WriteProperties() method will cause the result:
namespace Task03
{
    public class ReflectProperties
    {
        public class TestProperties
        {
            public string FirstName { get; set; }
            internal string LastName { get; set; }
            protected int Age { get; set; }
            private string PhoneNumber { get; set; }
        }
        public static void WriteProperties()
        {
            Type type = typeof(TestProperties);
            foreach (var item in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
            {
                Console.WriteLine($"Property name: {item.Name}\nProperty type: {item.PropertyType.FullName}\nRead-Write:    " +
                    $"{item.CanRead & item.CanWrite}\nAccessibility level: {GetVisibility(item.GetMethod)}\n");
            }
        }
        public static string GetVisibility(MethodInfo accessor) 
        {
            if (accessor.IsPublic)
                return "Public";
            else if (accessor.IsPrivate)
                return "Private";
            else if (accessor.IsFamily)
                return "Protected";
            else if (accessor.IsAssembly)
                return "Internal";
            else
                return "Protected Internal/Friend";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ReflectProperties refP = new ReflectProperties();
            //TestProperties properties = new TestProperties();
            //properties.FirstName = "FirstName";
            //properties.LastName = "LastName";
            //properties.Age = 30;
            //properties.PhoneNumber = "PhoneNumber";

            //properties.FirstName = "FirstName";
            //properties.LastName = "LastName";
            //properties.Age = 30;
            //properties.PhoneNumber = "PhoneNumber";

            //properties.FirstName = "FirstName";
            //properties.LastName = "LastName";
            //properties.Age = 30;
            //properties.PhoneNumber = "PhoneNumber";

            WriteProperties();
            Console.WriteLine("Hello World!");
        }
    }
}
