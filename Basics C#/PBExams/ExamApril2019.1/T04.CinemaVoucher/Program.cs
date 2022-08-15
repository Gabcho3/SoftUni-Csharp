using System;

namespace T04.CinemaVoucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int voucherSum = int.Parse(Console.ReadLine());
            string purchase = Console.ReadLine();

            int tickets = 0;
            int other = 0;
            bool notEnoughMoney = false;

            while(purchase != "End")
            {
                int length = purchase.Length;
                for(int i = 0; i < 2; i++)
                {
                    if(length <= 8)
                    {
                        other++;
                        voucherSum -= (char)purchase[i];
                        i++; //we need only first letter
                        if (voucherSum < 0)
                        {
                            notEnoughMoney = true;
                            other--; //can't purchase beacause of OUT OF MONEY
                            break;
                        }
                    }
                    else
                    {
                        if(i == 0)
                            tickets++; //purchase only ONE ticket in loop 
                        voucherSum -= (char)purchase[i];
                        if (voucherSum < 0)
                        {
                            notEnoughMoney = true;
                            tickets--; //can't purchase beacause of OUT OF MONEY
                            break;
                        }
                    }
                }
                if (notEnoughMoney)
                    break;

                purchase = Console.ReadLine();
            }
            Console.WriteLine(tickets);
            Console.WriteLine(other);   
        }
    }
}
