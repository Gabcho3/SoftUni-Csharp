using System;

namespace T03._Employee_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int id = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}\nAge: {age}\nEmployee ID: {id:d8}\nSalary: {salary:f2}");
        }
    }
}
