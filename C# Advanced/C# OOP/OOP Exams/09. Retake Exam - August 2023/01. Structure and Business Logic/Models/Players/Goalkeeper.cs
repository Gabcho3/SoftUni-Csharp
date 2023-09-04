using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class Goalkeeper : Player
    {
        private const double rating = 2.5;

        public Goalkeeper(string name) 
            : base(name, rating){}

        public override void IncreaseRating()
        {
            if (this.Rating + 0.75 <= 10)
            {
                this.Rating += 0.75;
            }
            else
            {
                this.Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            if (this.Rating - 1.25 >= 1)
            {
                this.Rating -= 1.25;
            }
            else
            {
                this.Rating = 1;
            }
        }
    }
}
