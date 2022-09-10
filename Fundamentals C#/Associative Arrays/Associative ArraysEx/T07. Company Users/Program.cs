using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace T07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ");

            List<string> ids = new List<string>();

            var companiesAndIds = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string companyName = input[0];
                string id = input[1];

                if(ids.Any(i => i == id))
                {
                    input = Console.ReadLine().Split(" -> ");
                    continue;
                }

                if (companiesAndIds.ContainsKey(companyName))
                    companiesAndIds[companyName].Add(id);

                else
                {
                    companiesAndIds.Add(companyName, new List<string>());
                    companiesAndIds[companyName].Add(id);
                }

                ids.Add(id);

                input = Console.ReadLine().Split(" -> ");
            }

            foreach(var company in companiesAndIds)
            {
                Console.WriteLine(company.Key);

                for (int i = 0; i < company.Value.Count; i++)
                    Console.WriteLine($"-- {company.Value[i]}");
            }
        }
    }
}
