using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Repositories.Contracts
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> models = new List<ISubject>();
        public IReadOnlyCollection<ISubject> Models => models;

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
