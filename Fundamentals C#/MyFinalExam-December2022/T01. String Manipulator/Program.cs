using System;

namespace T01._String_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                bool check = false;

                switch(command[0])
                {
                    case "Translate":
                        char ch = char.Parse(command[1]);
                        char replace = char.Parse(command[2]);
                        str = str.Replace(ch, replace);
                        break;

                    case "Includes":
                        check = true;
                        string substring = command[1];
                        string output = str.Contains(substring) ? "True" : "False";
                        Console.WriteLine(output);
                        break;

                    case "Start":
                        check = true;
                        substring = command[1];
                        output = str.IndexOf(substring) == 0 ? "True" : "False";
                        Console.WriteLine(output);
                        break;

                    case "Lowercase":
                        str = str.Replace(str, str.ToLower());
                        break;

                    case "FindIndex":
                        check = true;
                        ch = char.Parse(command[1]);
                        int index = str.LastIndexOf(ch);
                        Console.WriteLine(index);
                        break;

                    case "Remove":
                        int startIndex = int.Parse(command[1]);
                        int count = int.Parse(command[2]);
                        str = str.Remove(startIndex, count);
                        break;
                }

                if (!check)
                    Console.WriteLine(str);

                command = Console.ReadLine().Split();
            }
        }
    }
}
