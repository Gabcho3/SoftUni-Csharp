namespace T01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> portions = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> stamina = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int> peaks = new Dictionary<string, int>()
            {
                ["Vihren"] = 80,
                ["Kutelo"] = 90,
                ["Banski Suhodol"] = 100,
                ["Polezhan"] = 60,
                ["Kamenitza"] = 70
            };
            List<string> conqueredPeaks = new List<string>();

            while (true)
            {
                int sum = portions.Pop() + stamina.Dequeue();

                if (sum >= peaks.First().Value)
                {
                    conqueredPeaks.Add(peaks.First().Key);
                    peaks.Remove(peaks.First().Key);
                }

                if (peaks.Count == 0)
                {
                    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                    break;
                }

                if (stamina.Count == 0)
                {
                    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                    break;
                }
            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
            }
        }
    }
}