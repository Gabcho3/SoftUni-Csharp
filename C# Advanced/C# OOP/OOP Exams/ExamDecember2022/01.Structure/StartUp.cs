namespace ChristmasPastryShop
{
    using System;
    using ChristmasPastryShop.Core;
    using ChristmasPastryShop.Core.Contracts;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
