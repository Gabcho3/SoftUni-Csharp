using System;

namespace Т10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NOT MINE CODE!
            //Cr: https://github.com/DraksBG

            int filedSize = int.Parse(Console.ReadLine());

            int[] ladyBugsField = new int[filedSize]; 

            string[] occupiedIndexes = Console.ReadLine().Split(); 
 
            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currentIndex = int.Parse(occupiedIndexes[i]);
                if (currentIndex >= 0 && currentIndex < filedSize)
                {
                    ladyBugsField[currentIndex] = 1; //replace occuupiedIndexes to ladyBugField
                }
            }

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                bool isFirst = true; //firstFly of each ladyBug
                int currentIndex = int.Parse(commands[0]);
                while (currentIndex >= 0 && currentIndex < filedSize && ladyBugsField[currentIndex] != 0) //!= 0 --> there isn't any ladyBug on index
                {
                    if (isFirst)
                    {
                        ladyBugsField[currentIndex] = 0; //NOT on index {flying}
                        isFirst = false;
                    }

                    string direction = commands[1]; //right / left
                    int flightLenght = int.Parse(commands[2]); 
                    if (direction == "left")
                    {
                        currentIndex -= flightLenght; //changing index
                        if (currentIndex >= 0 && currentIndex < filedSize)
                        {
                            if (ladyBugsField[currentIndex] == 0)
                            {
                                ladyBugsField[currentIndex] = 1; //occupied index
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentIndex += flightLenght; //changing index
                        if (currentIndex >= 0 && currentIndex < filedSize)
                        {
                            if (ladyBugsField[currentIndex] == 0)
                            {
                                ladyBugsField[currentIndex] = 1; //occupied index
                                break;
                            }
                        }
                    }
                }

                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", ladyBugsField)); //printing field 
                                                                //0 -> empty index
                                                                //1 -> filled index
        }
    }
}
