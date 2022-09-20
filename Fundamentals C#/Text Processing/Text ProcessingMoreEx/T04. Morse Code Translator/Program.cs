using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var morseCodeTranslator = new Dictionary<char, string>
            {
                {'A', ".-"},
                {'B', "-..."},
                {'C', "-.-."},
                {'D', "-.."},
                {'E', "."},
                {'F', "..-."},
                {'G', "--."},
                {'H', "...."},
                {'I', ".."},
                {'J', ".---"},
                {'K', "-.-"},
                {'L', ".-.."},
                {'M', "--"},
                {'N', "-."},
                {'O', "---"},
                {'P', ".--."},
                {'Q', "--.-"},
                {'R', ".-."},
                {'S', "..."},
                {'T', "-"},
                {'U', "..-"},
                {'V', "...- "},
                {'W', ".--"},
                {'X', "-..-"},
                {'Y', "-.--"},
                {'Z', "--.."},
                {' ', "|"}
            };

            string[] morseCode = Console.ReadLine().Split();

            var output = new StringBuilder();

            foreach(string code in morseCode)
                output.Append(morseCodeTranslator.FirstOrDefault(k => k.Value == code).Key);

            Console.WriteLine(output);
        }
    }
}
