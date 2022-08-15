using System;

namespace T02.Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;
            int treated = 0;
            int untreated = 0;

            for(int day = 1; day <= period; day++)
            {
                int patients = int.Parse(Console.ReadLine());
                
                if(day % 3 == 0 && treated < untreated)
                {
                    doctors += 1;
                }
                
                 if(doctors >= patients)
                 {
                    treated += patients;
                 }
                if(doctors < patients)
                {
                    untreated += patients - doctors;
                    int untreatedForDay = patients - doctors;
                    treated += patients - untreatedForDay;
                }
            }
                Console.WriteLine($"Treated patients: {treated}.");
                Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
