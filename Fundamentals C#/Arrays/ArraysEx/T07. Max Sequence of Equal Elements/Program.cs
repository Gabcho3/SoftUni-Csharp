using System;
using System.Linq;

namespace T07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bestCount = int.MinValue;
            int bestIndex = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                int countSequenceLength = 1; //by DEFAULT

                for(int j = i + 1; j < nums.Length; j++) //checking sequences
                {
                    if (nums[i] == nums[j])
                        countSequenceLength++;
                    else
                        break;

                }

                if(countSequenceLength > bestCount) //finding MAX sequence
                {
                    bestCount = countSequenceLength;
                    bestIndex = i; //position of starting digit of sequence
                }
            }
            for(int k = 0; k < bestCount; k++) //printing digits
            {
                Console.Write(nums[bestIndex] + " ");
            }
        }
    }
}
