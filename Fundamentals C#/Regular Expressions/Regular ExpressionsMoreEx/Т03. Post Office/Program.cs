using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Т03._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');

            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            string firstPartPatern = @"([#$%*&])[A-Z]+\1";
            string secondPartPatern = @"\d+:[0-9][0-9]";
            string thirdPartPatern = @"[A-Z][a-z]+[-][A-Z][a-z]+|[A-Z][a-z]+";

            var firstMatch = Regex.Match(firstPart, firstPartPatern).ToString();
            var secondMatch = Regex.Matches(secondPart, secondPartPatern);
            var thirdMatch = Regex.Matches(thirdPart, thirdPartPatern);

            List<string> words = new List<string>();

            foreach(var word in thirdMatch)
            {
                words.Add(word.ToString());
            }

            for(int i = 0; i < firstMatch.Length; i++)
            {
                if (firstMatch[i] == '#' || firstMatch[i] == '$' || firstMatch[i] == '%' || firstMatch[i] == '*' || firstMatch[i] == '&')
                    continue;


                for (int j = 0; j < secondMatch.Count; j++)
                {
                    string charCode = string.Empty;
                    string lengthToString = "";
                    bool isLength = false;
                    bool exitLoop = false;

                    foreach (char ch in secondMatch[j].ToString())
                    {
                        if (ch == ':')
                        {
                            isLength = true;
                            continue;
                        }

                        if (isLength)
                            lengthToString += ch;
                        else
                            charCode += ch;

                    }

                    char letter = (char)int.Parse(charCode);
                    int length = int.Parse(lengthToString);

                    if (letter == firstMatch[i])
                    {
                        foreach (string word in words)
                        {
                            if (word.StartsWith(letter) && word.Length == length + 1)
                            {
                                Console.WriteLine(word);
                                words.Remove(word);
                                exitLoop = true;
                                break;
                            }
                        }
                    }

                    else
                        continue;

                    if (exitLoop)
                        break;
                }
            }
        }
    }
}
