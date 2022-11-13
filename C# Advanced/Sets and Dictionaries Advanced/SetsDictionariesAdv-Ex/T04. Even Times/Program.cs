using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nums = new Dictionary<int, int>(); //num, count

            for(int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if(!nums.ContainsKey(num))
                    nums.Add(num, 0);

                nums[num]++;
            }

            nums = nums.Where(x => x.Value % 2 == 0).ToDictionary(x => x.Key, x => x.Value);
            foreach (var num in nums)
                Console.WriteLine(num.Key);
        }
    }
}
