using System.Collections;
using System.Text;

internal class Program
{
    public static void Main(string[] args)
    {
        Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToList());
        Stack<int> substances = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToList());
        List<int> challenges = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

        while (true)
        {
            int currTool = tools.Dequeue();
            int currSubstance = substances.Pop(); ;
            int result = currTool * currSubstance;

            if (challenges.Contains(result))
            {
                challenges.Remove(result);
            }
            else
            {
                currTool++;
                tools.Enqueue(currTool);

                currSubstance--;
                if (currSubstance > 0)
                {
                    substances.Push(currSubstance);
                }
            }

            if ((substances.Count == 0 || tools.Count == 0) && challenges.Count > 0)
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                break;
            }

            if (challenges.Count == 0)
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                break;
            }
        }

        if (tools.Count > 0)
            Console.WriteLine("Tools: " + string.Join(", ", tools));

        if (substances.Count > 0)
            Console.WriteLine("Substances: " + string.Join(", ", substances));

        if (challenges.Count > 0)
            Console.WriteLine("Challenges: " + string.Join(", ", challenges));
    }
}