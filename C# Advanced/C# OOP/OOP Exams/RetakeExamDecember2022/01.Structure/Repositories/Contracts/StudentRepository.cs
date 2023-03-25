using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Repositories.Contracts
{
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly List<IStudent> models = new List<IStudent>();
        public IReadOnlyCollection<IStudent> Models => models;

        public void AddModel(IStudent student)
        {
            models.Add(student);
        }

        public IStudent FindById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }

        public IStudent FindByName(string name)
        {
            return Models.FirstOrDefault(m => m.FirstName == name.Split(" ", System.StringSplitOptions.RemoveEmptyEntries)[0] 
            && m.LastName == name.Split(" ", System.StringSplitOptions.RemoveEmptyEntries)[1]);
        }
    }
}
