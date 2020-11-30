using System;
//Based on specifications, we need to create an interface ILead and a TeamLead class to implement it.
//t8_1
//Later another role like Manager, who assigns tasks to TeamLead and will not work on the tasks, is introduced into the system. We tried to implement an ILead interface in the Manager class directly.
//t8_2
//Here we are forcing the Manager class to implement a WorkOnTask() method without a purpose. This is wrong. The design violates ISP. 
//But later one more role appears: Programmer that can only work on tasks. We need to divide the responsibilities by segregating the ILead interface. 
//Your task is to refactor solution.
namespace Task09
{   
    public interface ILead
    {
        void AssignTask();
        void CreateSubTask();
    }    
    public interface IProgrammer
    {
        void WorkOnTask();
    }
    public class TeamLead : ILead, IProgrammer
    {
        public void AssignTask() { }
        public void CreateSubTask() { }
        public void WorkOnTask() { }
    }
    public class Manager : ILead
    {
        public void AssignTask() { }
        public void CreateSubTask() { }
    }
    public class Programmer : IProgrammer
    {
        public void WorkOnTask() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
