using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\+359([-|\s])2\1[0-9]{3}\1[0-9]{4}\b"; //+359 '-' or space 2 <group1> 0-9 <group1> 0-9    group1 = '-' or ' '

            string phoneNumbers = Console.ReadLine();

            MatchCollection validNumbers = Regex.Matches(phoneNumbers, patern);

            Console.WriteLine(string.Join(", ", validNumbers));
        }
    }
}
