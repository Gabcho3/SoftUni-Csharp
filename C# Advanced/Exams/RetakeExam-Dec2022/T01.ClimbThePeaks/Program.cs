namespace T01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string[]> peaks = new Queue<string[]>();
            peaks.Enqueue(new string[2] { "Vihren", "80" });
            peaks.Enqueue(new string[2] { "Kutelo", "90" });
            peaks.Enqueue(new string[2] { "Banski Suhodol", "100" });
            peaks.Enqueue(new string[2] { "Polezhan", "60" });
            peaks.Enqueue(new string[2] { "Kamenitza", "70" });

            Stack<int> foodPortions = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            Queue<int> stamina = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            List<string> peaksClimbed = new List<string>();
            int dayCount = 1;
            while (peaks.Count > 0)
            {
                if ((foodPortions.Count == 0 && stamina.Count == 0) || dayCount == 7)
                {
                    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                    PrintPeaks(peaksClimbed);
                    return;
                }

                int sum = foodPortions.Pop() + stamina.Dequeue();
                int difficultyLevel = int.Parse(peaks.Peek()[1]);

                if (sum >= difficultyLevel)
                {
                    peaksClimbed.Add(peaks.Dequeue()[0]);
                }

                else
                    dayCount++;
            }
            Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            PrintPeaks(peaksClimbed);
        }

        private static void PrintPeaks(List<string> peaksClimbed)
        {
            if (peaksClimbed.Count == 0)
                return;

            Console.WriteLine("Conquered peaks:");
            foreach (var peak in peaksClimbed)
            {
                Console.WriteLine(peak);
            }
        }
    }
}