using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models = new List<IHero>();

        public IReadOnlyCollection<IHero> Models => models;

        public void Add(IHero model)
        {
            models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            if (models.Remove(model))
                return true;

            return false;
        }
    }
}
