using System;

namespace T08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameStudent = Console.ReadLine();
            int classes = 1;
            double total = 0;
            bool fail = false;
            while(classes <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                int excluded = 0;
                if(grade < 4.00) 
                {
                    excluded++;
                    if(excluded > 1)
                    {
                        fail = true;
                        break;
                    }
                    continue;
                }
                total += grade;
                classes++;
            }
            if(fail)
            {
                Console.WriteLine($"{nameStudent} has been excluded at {classes} grade");
            }
            else
            {
                double average = total / 12;
                Console.WriteLine($"{nameStudent} graduated. Average grade: {average:F2}");
            }
             
        }
    }
}
