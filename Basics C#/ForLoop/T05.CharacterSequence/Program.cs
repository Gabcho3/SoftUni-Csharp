using System;

namespace T05.CharacterSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int letter = text.Length;
            for(int i = 0; i < letter; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
