using System;
using System.Reflection;
using System.Text.RegularExpressions;
/*Create a class ReflectFields with public static string field Name and three public static int fields: MeasureX, MeasureY, and MeasureZ.
Within this class define a public static method OutputFields() which contains the loop through fields of the class ReflectFields and display(in console) their names and values as the formatted string ("{0} (<type>) = {1}", name, value). < type > means the string representation of int or string type of field.
Note. System.Reflection provides a way to enumerate fields and properties. We get the FieldInfo objects for those fields and then display them.
After the values are set and the method has invoked the output:*/
namespace Task01
{
    public class ReflectFields
    {
        public static string Name;
        public static int MeasureX;
        public static int MeasureY;
        public static int MeasureZ;
        public static void OutputFields()
        {
            Type type = typeof(ReflectFields);
            foreach (FieldInfo item in type.GetFields())
            {
                Console.WriteLine($"{item.Name} ({Regex.Replace(item.FieldType.Name, "[0-9]", "", RegexOptions.IgnoreCase).ToLower()}) = {item.GetValue(item)}");
            }
        }
    }   
    class Program
    {
        static void Main(string[] args)
        {
            ReflectFields.MeasureX = 100;
            ReflectFields.MeasureY = 50;
            ReflectFields.MeasureZ = 300;
            ReflectFields.Name = "Programming";
            ReflectFields.OutputFields();
            Console.WriteLine("Hello World!");
        }
    }
}
