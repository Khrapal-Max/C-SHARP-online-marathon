using System;
using System.Collections.Generic;
//Note! this is additional task that requires understanding of HashSet, so please, read the article: HashSet before implementing the task.

//Implement class Student : add the constructor (with field initializations) and necessary methods into it.

//Add public static GetCommonStudents() method to Student class that returns a HashSet of common elements of two student lists.

//For example, for a given list1 [Student [Id=1, Name=Ivan], Students[Id = 2, Name = Petro], Students[Id = 3, Name = Stepan]] and list2[Student[Id = 1, Name = Ivan], Students[Id = 3, Name = Stepan], 
//Students[Id = 4, Name = Andriy]] you should get [Student [Id=3, name=Stepan], Students[Id = 1, Name = Ivan]].
namespace Level03Task01
{
    class Student
    {      
        public int Id { get; }
        public string Name { get; }  
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public static HashSet<Student> GetCommonStudents(List<Student> studentsFirst, List<Student> studentSecond) 
        {
            HashSet<Student> studentsOne = new HashSet<Student>(studentsFirst);
            HashSet<Student> studentSTwo = new HashSet<Student>(studentSecond);
            studentsOne.IntersectWith(studentSTwo);
            return studentsOne ?? null;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Name == student.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsA = new List<Student>
            {
                new Student(1, "Ivan"),
                new Student(2, "Petro"),
                new Student(3, "Stepan")
            };
            List<Student> studentsB = new List<Student>
            {
                new Student(1, "Ivan"),
                new Student(3, "Stepan"),
                new Student(4, "Andriy")
            };
            
        }
    }
}
