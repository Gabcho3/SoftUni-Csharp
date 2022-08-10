using System;
using System.Collections.Generic;
using System.Linq;

namespace T08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "3:1")
            {
                switch(command[0])
                {
                    case "merge":
                        Merge(data, command);
                        break;
                    case "divide":
                        Divide(data, command);
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(" ", data));
        }

        static void Merge(List<string> data, string[] command)
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);

            if (startIndex >= data.Count && endIndex >= data.Count)
                return;

            if (startIndex < 0 && endIndex < data.Count)
                startIndex = 0;

            if (startIndex < 0 && endIndex < 0)
                return;

            if (startIndex < 0 && endIndex >= data.Count)
            {
                startIndex = 0;
                endIndex = data.Count - 1;
            }

            if (endIndex >= data.Count && startIndex < data.Count)
                endIndex = data.Count - 1;

            int merges = endIndex - startIndex;
            int mergesCount = 0;

            for(int i = startIndex + 1; i <= endIndex; i++)
            {
                data[startIndex] += data[i];
                data.RemoveAt(i);
                i--; 

                if (endIndex >= data.Count)
                    endIndex--;

                mergesCount++;
                if (mergesCount >= merges)
                    break;
            }
        }

        static void Divide(List<string> data, string[] command)
        {
            int index = int.Parse(command[1]);
            int partitions = int.Parse(command[2]);

            int partitionsCount = 0;

            string letters = data[index];
            string lettersToAdd = "";

            int pieces = data[index].Length / partitions;
            int piecesCount = 0;

            bool joinsOneTime = false;

            for(int i = 0; i < data[index].Length; i++)
            {
                lettersToAdd += letters[i];
                piecesCount++;

                if(data[index].Length % partitions != 0)
                {
                    if(partitionsCount == partitions - 1 && !joinsOneTime)
                    {
                        joinsOneTime = true;
                        pieces++;
                    }
                }

                if (piecesCount == pieces)
                {
                    partitionsCount++;
                    data.Insert(index + partitionsCount, lettersToAdd);
                    lettersToAdd = "";
                    piecesCount = 0;
                }

                if (partitionsCount == partitions)
                    break;
            }
            data.RemoveAt(index);
        }
    }
}
