using Handball.Core;
using Handball.Core.Contracts;
using Handball.Models.Players;

namespace Handball
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();           
        }
    }
}
