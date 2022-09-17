using System;

namespace T03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string result = Console.ReadLine();

            while(result.Contains(key))
            {
                int index = result.IndexOf(key);
                result = result.Remove(index, key.Length);
            }

            Console.WriteLine(result);
        }
    }
}