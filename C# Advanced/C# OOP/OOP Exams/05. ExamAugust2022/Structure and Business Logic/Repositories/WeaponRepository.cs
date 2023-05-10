using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons = new List<IWeapon>();

        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(w => w.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            int weaponsCountBeforeRemoving = weapons.Count;
            weapons.RemoveAll(w => w.GetType().Name == name);

            return weaponsCountBeforeRemoving > weapons.Count;
        }
    }
}
