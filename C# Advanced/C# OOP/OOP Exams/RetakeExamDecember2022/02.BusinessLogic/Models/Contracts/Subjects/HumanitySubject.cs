using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Contracts.Subjects
{
    public class HumanitySubject : Subject
    {
        private const double rate = 1.15;

        public HumanitySubject(int id, string name)
            : base(id, name, rate) { }
    }
}
