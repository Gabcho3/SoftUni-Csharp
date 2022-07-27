using System;
using System.Linq;

namespace T07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string output = null;
            int maxLength = int.MinValue;
            string maxSequence = null;
            for (int i = 0; i < nums.Length - 1; i++) //-1 --> row 17 "nums[i + 1]"
            {
                if (nums[i] == nums[i + 1])
                {
                    output += nums[i];
                }
                else
                    output = "";

                int outputLength = output.Length;

                if (outputLength > maxLength)
                {
                    maxLength = outputLength;
                    maxSequence = output;
                }
            }
            if (output == "")
            {
                maxSequence += nums[0];
            }
            else
                maxSequence += maxSequence[0]; //one more digit cause of ROWS 17-20 //CHECK DEBUG
            int[] result = new int[maxLength + 1]; //+1 --> one MORE digit
            for (int i = 0; i < maxLength + 1; i++) //+1 --> one MORE digit
            {
                result[i] += int.Parse(maxSequence[i].ToString()); //to SPLIT digits
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
