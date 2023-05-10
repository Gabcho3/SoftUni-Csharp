using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models = new List<IWeapon>();

        public IReadOnlyCollection<IWeapon> Models => models;

        public void Add(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            if (models.Remove(model))
                return true;

            return false;
        }
    }
}
