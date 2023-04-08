using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models = new List<IRobot>();

        public void AddNew(IRobot model)
        {
            models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(r => r.InterfaceStandards.Any(i => i == interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models() => models;

        public bool RemoveByName(string typeName)
        {
            IRobot robotToRemove = models.FirstOrDefault(s => s.GetType().Name == typeName);
            if (models.Remove(robotToRemove))
            {
                return true;
            }
            return false;
        }
    }
}
