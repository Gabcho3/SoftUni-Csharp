using System;

namespace T09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //11 дни = 10 нощувки; дни - 1
            //room for one person: no discount
            //apartment: <10дни(30% нам); >=10 и <=15(35%); >15(50%)
            //pr apartment: <10дни(10% нам); >=10 и <=15(15%); >15(20%)
            //намаление = сума - (сума * %)
            //позитивна оценка: +25% нам; негативна оценка: -10% нам
            double days = int.Parse(Console.ReadLine()); double ng = days - 1;
            string pl = Console.ReadLine();
            string gr = Console.ReadLine();
            double dis = 0.00;
            double dis1 = 0.00;

            if (ng < 10)
            {
                if (pl == "apartment")
                {
                    if (gr == "positive")
                    {
                        dis = (ng * 25) - (ng * 25 * 0.30);
                        dis1 = dis + (dis * 0.25);
                    }
                    if (gr == "negative")
                    {
                        dis = (ng * 25) - (ng * 25 * 0.30);
                        dis1 = dis - (dis * 0.10);
                    }
                }
                if (pl == "president apartment")
                {
                    if (gr == "positive")
                    {
                        dis = (ng * 35) - (ng * 35 * 0.10);
                        dis1 = dis + (dis * 0.25);
                    }
                    if (gr == "negative")
                    {
                        dis = (ng * 35) - (ng * 35 * 0.10);
                        dis1 = dis - (dis * 0.10);
                    }

                }
            }

            if (ng >= 10 && ng <= 15)
            {
                if (pl == "apartment")
                {
                    if (gr == "positive")
                    {
                        dis = (ng * 25) - (ng * 25 * 0.35);
                        dis1 = dis + (dis * 0.25);
                    }
                    if (gr == "negative")
                    {
                        dis = (ng * 25) - (ng * 25 * 0.35);
                        dis1 = dis - (dis * 0.10);
                    }
                }
                if (pl == "president apartment")
                {
                    if (gr == "positive")
                    {
                        dis = (ng * 35) - (ng * 35 * 0.15);
                        dis1 = dis + (dis * 0.25);
                    }
                    if (gr == "negative")
                    {
                        dis = (ng * 35) - (ng * 35 * 0.15);
                        dis1 = dis - (dis * 0.10);
                    }

                }
            }

            if (ng > 15)
            {
                if (pl == "apartment")
                {
                    if (gr == "positive")
                    {
                        dis = (ng * 25) - (ng * 25 * 0.50);
                        dis1 = dis + (dis * 0.25);
                    }
                    if (gr == "negative")
                    {
                        dis = (ng * 25) - (ng * 25 * 0.50);
                        dis1 = dis - (dis * 0.10);
                    }
                }
            }

            if (pl == "president apartment")
            {
                if (gr == "positive")
                {
                    dis = (ng * 35) - (ng * 35 * 0.20);
                    dis1 = dis + (dis * 0.25);
                }
                if (gr == "negative")
                {
                    dis = (ng * 35) - (ng * 35 * 0.20);
                    dis1 = dis - (dis * 0.10);
                }
            }

            if (ng > 0)
            {
                if (pl == "room for one person")
                {
                    if (gr == "positive")
                    {
                        dis = (ng * 18);
                        dis1 = dis + (dis * 0.25);
                    }
                    if (gr == "negative")
                    {
                        dis = (ng * 18);
                        dis1 = dis - (dis * 0.10);
                    }
                }
            }
            Console.WriteLine($"{dis1:F2}");
        }
    }
}
