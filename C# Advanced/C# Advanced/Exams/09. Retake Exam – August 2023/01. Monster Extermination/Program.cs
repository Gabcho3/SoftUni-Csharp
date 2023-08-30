namespace _01._Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> armors = new Queue<int>(Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> strikes = new Stack<int>(Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));


            int totalKilled = 0;
            while (armors.Count > 0 && strikes.Count > 0)
            {
                int currArmor = armors.Dequeue();
                int currStrike = strikes.Pop();

                if (currStrike >= currArmor)
                {
                    totalKilled++;
                    currStrike -= currArmor;

                    if (currStrike > 0)
                    {
                        if (strikes.Count > 0)
                        {
                            currStrike += strikes.Pop();
                        }
                        strikes.Push(currStrike);
                    }
                }

                else
                {
                    currArmor -= currStrike;
                    armors.Enqueue(currArmor);
                }
            }

            if (armors.Count == 0)
                Console.WriteLine("All monsters have been killed!");

            if(strikes.Count == 0)
                Console.WriteLine("The soldier has been defeated.");

            Console.WriteLine($"Total monsters killed: {totalKilled}");
        }
    }
}