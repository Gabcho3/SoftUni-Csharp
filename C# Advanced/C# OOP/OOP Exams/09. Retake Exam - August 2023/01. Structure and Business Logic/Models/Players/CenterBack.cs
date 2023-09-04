using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class CenterBack : Player
    {
        private const double rating = 4;

        public CenterBack(string name)
            : base(name, rating) { }

        public override void IncreaseRating()
        {
            if (this.Rating + 1 <= 10)
            {
                this.Rating += 1;
            }
        }

        public override void DecreaseRating()
        {
            if (this.Rating - 1 >= 1)
            {
                this.Rating -= 1;
            }
        }
    }
}
