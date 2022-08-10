using System;
using System.Collections.Generic;
using System.Linq;
namespace T10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string[] action = Console.ReadLine().Split(":").ToArray();

            while (action[0] != "course start")
            {
                bool exist = lessons.Contains(action[1]);
                bool haveExFirst = lessons.Contains(action[1] + "-Exercise");

                switch (action[0])
                {
                    case "Add":
                        Add(lessons, action, exist);
                        break;

                    case "Insert":
                        Insert(lessons, action, exist);
                        break;

                    case "Remove":
                        Remove(lessons, action, exist, haveExFirst);
                        break;

                    case "Swap":
                        bool haveExSecond = lessons.Contains(action[2] + "-Exercise");
                        Swap(lessons, action, exist, haveExFirst, haveExSecond);
                        break;

                    case "Exercise":
                        Exsercise(lessons, action, exist, haveExFirst);
                        break;
                }

                action = Console.ReadLine().Split(":").ToArray();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }

        static void Add(List<string> lessons, string[] action, bool exist)
        {
            if (!exist)
                lessons.Add(action[1]);
        }

        static void Insert(List<string> lessons, string[] action, bool exist)
        {
            if (!exist)
                lessons.Insert(int.Parse(action[2]), action[1]);
        }

        static void Remove(List<string> lessons, string[] action, bool exist, bool haveEx)
        {
            if (exist)
                lessons.Remove(action[1]);

            if (haveEx)
                lessons.Remove(action[1] + "-Exercise");
        }

        static void Swap(List<string> lessons, string[] action, bool exist, bool haveExFirst, bool haveExSecond)
        {
            string lessonToSwap1 = action[1];
            string lessonToSwap2 = action[2];

            if (exist)
            {
                for (int i = 0; i < lessons.Count; i++)
                {
                    if (lessons[i] != lessonToSwap1)
                        continue;

                    for (int j = 0; j < lessons.Count; j++)
                    {
                        if (lessons[j] != lessonToSwap2)
                            continue;

                        lessons[i] = lessonToSwap2;
                        if (haveExFirst)
                        {
                            lessons.Insert(j + 1, lessons[i + 1]);
                            lessons.RemoveAt(i + 2); //i + 2-- > we insert one index
                        }

                        lessons[j] = lessonToSwap1;
                        if (haveExSecond)
                        {
                            lessons.Insert(i + 1, lessons[j + 1]);
                            lessons.RemoveAt(j + 2); //j + 2 --> we insert one index
                        }

                        break;
                    }
                    break;
                }
            }
        }

        static void Exsercise(List<string> lessons, string[] action, bool exist, bool haveEx)
        {
            string exerciseOfLesson = action[1];

            if (exist && !haveEx)
            {
                for (int i = 0; i < lessons.Count; i++)
                {
                    if (lessons[i] == exerciseOfLesson)
                    {
                        lessons.Insert(i + 1, exerciseOfLesson + "-Exercise");
                    }
                }
            }

            else
            {
                lessons.Add(exerciseOfLesson);
                lessons.Add(exerciseOfLesson + "-Exercise");
            }
        }
    }
}