using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append($"{Model}:\n");
            output.Append($"  {Engine.Model}:\n");
            output.Append($"    Power: {Engine.Power}\n");
            
            if(Engine.Displacement != 0)
            {
                output.Append($"    Displacement: {Engine.Displacement}\n");
            }

            else
            {
                output.Append($"    Displacement: n/a\n");
            }

            if (Engine.Efficiency != null)
            {
                output.Append($"    Efficiency: {Engine.Efficiency}\n");
            }

            else
            {
                output.Append($"    Efficiency: n/a\n");
            }

            if (Weight != 0)
            {
                output.Append($"  Weight: {Weight}\n");
            }

            else
            {
                output.Append($"  Weight: n/a\n");
            }

            if (Color != null)
            {
                output.Append($"  Color: {Color}\n");
            }

            else
            {
                output.Append($"  Color: n/a\n");
            }

            return output.ToString();
        }
    }
}
