using System;

namespace T04.CarNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startInterval = int.Parse(Console.ReadLine());
            int endInterval = int.Parse(Console.ReadLine());

            for (int Carnum = 1111; Carnum <= 9999; Carnum++)
            {
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                bool num1IsEven = false;
                bool num1IsOdd = false;
                bool numIsZero = false;
                bool isSpecial = false;
                bool numIsNotValid = false;

                string everyNum = Carnum.ToString();
                for (int i = 0; i < everyNum.Length; i++)
                {
                    int number = int.Parse(everyNum[i].ToString());

                    if (i == 0)
                    {
                        if(number < startInterval || number > endInterval)
                        {
                            numIsNotValid = true;
                            break;
                        }
                        else
                        {
                            num1 = number;
                        }
                    }
                    else if (i == 1)
                    {
                        if (number < startInterval || number > endInterval)
                        {
                            numIsNotValid = true;
                            break;
                        }
                        else
                        {
                            num2 = number;
                        }
                    }
                    else if (i == 2)
                    {
                        if (number < startInterval || number > endInterval)
                        {
                            numIsNotValid = true;
                            break;
                        }
                        else
                        {
                            num3 = number;
                        }
                    }
                    else if (i == 3)
                    {
                        if (number < startInterval || number > endInterval)
                        {
                            numIsNotValid = true;
                            break;
                        }
                        else
                        {
                            num4 = number;
                        }
                    }
                }
                if (num1 == 0 || num2 == 0 || num3 == 0 || num4 == 0)
                { 
                    numIsZero = true;
                }
                while (!isSpecial)
                {
                    if(numIsNotValid)
                    {
                        break;
                    }  

                    if (numIsZero)
                    {
                        break;
                    }

                    if (num1 % 2 == 0)
                    {
                        num1IsEven = true;
                        if (num1IsEven)
                        {
                            if (num4 % 2 == 0)
                            {
                                isSpecial = false;
                                break;
                            }
                            else
                            {
                                isSpecial = true;
                            }
                        }
                    }

                    if (num1 % 2 != 0)
                    {
                        num1IsOdd = true;
                        if (num1IsOdd)
                        {
                            if (num4 % 2 != 0)
                            {
                                isSpecial = false;
                                break;
                            }
                            else
                            {
                                isSpecial = true;
                            }
                        }
                    }

                    if (num1 > num4)
                    {
                        isSpecial = true;
                    }
                    else
                    {
                        isSpecial = false;
                        break;
                    }

                    if ((num2 + num3) % 2 == 0)
                    {
                        isSpecial = true;
                    }
                    else
                    {
                        isSpecial = false;
                        break;
                    }
                }
                    if (isSpecial)
                    {
                        Console.Write($"{Carnum} ");
                    }
            }
        }
    }
}
