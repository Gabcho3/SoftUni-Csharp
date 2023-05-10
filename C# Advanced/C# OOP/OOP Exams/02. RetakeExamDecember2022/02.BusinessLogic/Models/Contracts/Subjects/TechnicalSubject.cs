using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Contracts.Subjects
{
    public class TechnicalSubject : Subject
    {
        private const double rate = 1.3;

        public TechnicalSubject(int id, string name)
            : base(id, name, rate) { }
    }
}
