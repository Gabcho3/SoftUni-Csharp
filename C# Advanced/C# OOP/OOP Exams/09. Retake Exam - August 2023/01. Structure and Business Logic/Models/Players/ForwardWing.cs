using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class ForwardWing : Player
    {
        private const double rating = 5.5;

        public ForwardWing(string name)
            : base(name, rating) { }

        public override void IncreaseRating()
        {
            if (this.Rating + 1.25 <= 10)
            {
                this.Rating += 1.25;
            }
            else
            {
                this.Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            if (this.Rating - 0.75 >= 1)
            {
                this.Rating -= 0.75;
            }
            else
            {
                this.Rating = 1;
            }
        }
    }
}
