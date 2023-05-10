using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units = new List<IMilitaryUnit>();

        public IReadOnlyCollection<IMilitaryUnit> Models => units;

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return units.FirstOrDefault(u => u.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            int beforeRemovingCount = units.Count;
            units.RemoveAll(u => u.GetType().Name == name);

            return beforeRemovingCount > units.Count;
        }
    }
}
