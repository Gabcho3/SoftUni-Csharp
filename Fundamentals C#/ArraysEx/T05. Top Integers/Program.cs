using System;
using System.Linq;

namespace T05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //top integer is an integer that is greater than all the elements to its right
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for(int i = 0; i < nums.Length; i++)
            {
                bool isGreater = true;  

                for(int j = i + 1; j < nums.Length; j++)//checking right side elements
                {
                    if (nums[i] <= nums[j])
                    {
                        isGreater = false;
                        break;
                    }
                }

                if(isGreater)
                {
                    Console.Write(nums[i] + " ");
                }
            }
        }
    }
}
