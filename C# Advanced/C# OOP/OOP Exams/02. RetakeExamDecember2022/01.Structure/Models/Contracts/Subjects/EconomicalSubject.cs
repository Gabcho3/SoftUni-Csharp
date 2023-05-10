using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Contracts.Subjects
{
    public class EconomicalSubject : Subject
    {
        private const double rate = 1.0;

        public EconomicalSubject(int id, string name)
            : base(id, name, rate) { }
    }
}
