using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> delicacies = new List<IDelicacy>();

        public IReadOnlyCollection<IDelicacy> Models => delicacies;

        public void AddModel(IDelicacy delicacy)
        {
            delicacies.Add(delicacy);
        }
    }
}
