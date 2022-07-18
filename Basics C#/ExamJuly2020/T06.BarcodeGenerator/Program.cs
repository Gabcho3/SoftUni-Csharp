using System;

namespace T06.BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startInterval = int.Parse(Console.ReadLine());
            int endInterval = int.Parse(Console.ReadLine());

            for (int barcode = startInterval; barcode <= endInterval; barcode++)
            {
                string everynum = barcode.ToString();
                string start = startInterval.ToString();
                string end = endInterval.ToString();
                bool validBarcode = false;
                for (int i = 0; i < everynum.Length; i++)
                {
                    int num = int.Parse(everynum[i].ToString()); //every num of barcode

                    int first = int.Parse(start[i].ToString()); //every num of startInterval
                    int last = int.Parse(end[i].ToString()); //every num of endInterval

                    if (num % 2 != 0 && num >= first && num <= last)
                    {
                        validBarcode = true;
                    }
                    else
                    {
                        validBarcode = false;
                        break;
                    }
                }
                if (validBarcode)
                {
                    Console.Write(barcode + " ");
                }
            }
        }
    }
}
