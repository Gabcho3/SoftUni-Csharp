using System;

namespace T06.HighJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wanted = int.Parse(Console.ReadLine()); 
            int want = wanted - 30;//start training

            int jumps = 0;
            bool failed = false;

            while(wanted >= want)
            {
                for (int tries = 1; tries <= 3; tries++)
                {
                    int jumped = int.Parse(Console.ReadLine());
                    jumps++;
                    if(jumped > want)
                    {
                        break;
                    }
                    if (tries == 3) { failed = true; }
                }
                if(failed) { break; }
                want += 5;
            }
            if(failed)
            {
                Console.WriteLine($"Tihomir failed at {want}cm after {jumps} jumps.");
                return;
            }
            Console.WriteLine($"Tihomir succeeded, he jumped over {wanted}cm after {jumps} jumps.");
        }
    }
}
