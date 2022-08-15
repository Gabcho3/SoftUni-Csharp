using System;

namespace T01.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int borderNum1 = int.Parse(Console.ReadLine());
            int borderNum2 = int.Parse(Console.ReadLine());
            int borderNum3 = int.Parse(Console.ReadLine());


            for(int pins = 111; pins < 999; pins++)
            {
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                bool isValid = false;
                bool numIsNotValid = false;
                bool num2IsNotPrime = false;

                string everyNum = pins.ToString();
                for(int i = 0; i < everyNum.Length; i++)
                {
                    int pin = int.Parse(everyNum[i].ToString());
                    if(pin == 0)
                    {
                        numIsNotValid = true;
                        break;
                    }
                    if(i == 0)
                    {
                        if(pin > borderNum1)
                        {
                            numIsNotValid = true;
                            break;
                        }
                        else
                        {
                            num1 = pin;
                        }
                    }
                    if(i == 1)
                    {
                        if(pin > borderNum2)
                        {
                            numIsNotValid = true;
                            break;
                        }
                        else
                        {
                            num2 = pin;
                        }
                    }
                    if(i == 2)
                    {
                        if(pin > borderNum3)
                        {
                            numIsNotValid = true;
                            break;
                        }
                        else
                        {
                            num3 = pin;
                        }
                    }
                }


                while (!isValid)
                {
                    if(numIsNotValid)
                    {
                        break;
                    }
                    if (num1 % 2 == 0 && num3 % 2 == 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                    if (num2 >= 2 && num2 <= 7)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                    for(int divider = 2; divider < num2; divider++)
                    {
                        if(num2 % divider == 0)
                        {
                            num2IsNotPrime = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if(num2IsNotPrime)
                    {
                        isValid = false;
                        break;
                    }
                }
                if(isValid)
                {
                    Console.Write(num1 + " ");
                    Console.Write(num2 + " ");
                    Console.Write(num3 + " ");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            
        }
    }
}
