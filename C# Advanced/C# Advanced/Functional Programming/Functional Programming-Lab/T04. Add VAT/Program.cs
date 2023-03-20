using System.Transactions;

namespace T04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = pr => pr *= 1.20;
            Func<double, string> formater = pr => $"{pr:f2}";
            Console.WriteLine(string.Join(Environment.NewLine
                ,Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(pr => addVat(pr))
                .Select(pr => formater(pr))
                .ToArray()));
        }
    }
}