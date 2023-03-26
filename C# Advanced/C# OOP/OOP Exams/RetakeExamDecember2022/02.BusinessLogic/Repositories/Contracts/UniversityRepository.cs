using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Repositories.Contracts
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models = new List<IUniversity>();
        public IReadOnlyCollection<IUniversity> Models => models;

        public void AddModel(IUniversity university)
        {
            models.Add(university);
        }

        public IUniversity FindById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
