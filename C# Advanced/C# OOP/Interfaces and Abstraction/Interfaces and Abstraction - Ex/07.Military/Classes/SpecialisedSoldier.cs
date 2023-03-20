using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _07.Military.Classes
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string firstName, string lastName, string id, decimal salary, string corps)
            : base(firstName, lastName, id, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get { return corps; }
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    return;
                }
                corps = value;
            }
        }
    }
}
