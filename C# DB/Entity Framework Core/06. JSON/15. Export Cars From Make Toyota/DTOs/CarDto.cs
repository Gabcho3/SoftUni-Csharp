using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Import_Cars
{
    public class CarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int TraveledDistance { get; set; }

        public List<int> PartsId { get; set; }
    }
}
