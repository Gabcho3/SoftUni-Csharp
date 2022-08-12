using System;

namespace T05._Decrypting_Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte key = sbyte.Parse(Console.ReadLine());
            sbyte lines = sbyte.Parse(Console.ReadLine());
            
            for(int i = 0; i < lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int output = (int)letter + key;
                char outputLetter = (char)output;
                Console.Write(outputLetter);
            }
        }
    }
}
