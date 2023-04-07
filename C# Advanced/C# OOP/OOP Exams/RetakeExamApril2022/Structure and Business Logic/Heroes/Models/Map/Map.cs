using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = players.Where(h => h.GetType().Name == "Barbarian").ToList();
            List<IHero> knights = players.Where(h => h.GetType().Name == "Knight").ToList();

            while(barbarians.Any(b => b.IsAlive) && knights.Any(k => k.IsAlive))
            {
                foreach(var knight in knights.Where(k => k.IsAlive))
                {
                    foreach(var barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (var knight in knights.Where(k => k.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            if (knights.All(k => !k.IsAlive))
            {
                return string.Format(OutputMessages.MapFigthBarbariansWin, barbarians.Where(b => !b.IsAlive).Count());
            }

            return string.Format(OutputMessages.MapFightKnightsWin, knights.Where(k => !k.IsAlive).Count());
        }
    }
}
