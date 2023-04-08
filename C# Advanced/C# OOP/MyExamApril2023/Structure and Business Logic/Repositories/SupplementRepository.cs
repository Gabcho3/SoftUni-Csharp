using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> models = new List<ISupplement>();

        public void AddNew(ISupplement model)
        {
            models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        }

        public IReadOnlyCollection<ISupplement> Models() => models;

        public bool RemoveByName(string typeName)
        {
            ISupplement supplementToRemove = models.FirstOrDefault(s => s.GetType().Name == typeName);
            if (models.Remove(supplementToRemove))
            {
                return true;
            }
            return false;
        }
    }
}
