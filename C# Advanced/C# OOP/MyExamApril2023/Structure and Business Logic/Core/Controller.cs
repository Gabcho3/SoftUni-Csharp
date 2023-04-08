using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements = new SupplementRepository();
        private RobotRepository robots = new RobotRepository();
        private List<string> robotTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "RobotService.Models.Robots").Select(t => t.Name).ToList();
        private List<string> supplementTypes = Assembly.GetExecutingAssembly().GetTypes()
           .Where(t => t.Namespace == "RobotService.Models.Supplements").Select(t => t.Name).ToList();

        public string CreateRobot(string model, string typeName)
        {
            if (!robotTypes.Contains(typeName))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            var robotType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);
            IRobot robot = Activator.CreateInstance(robotType, new object[] { model }) as IRobot;
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (!supplementTypes.Contains(typeName))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            var supplementType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);
            ISupplement supplmenet = Activator.CreateInstance(supplementType) as ISupplement;
            supplements.AddNew(supplmenet);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsWithGivenInterface = robots.Models().Where(r => r.InterfaceStandards.Any(i => i == intefaceStandard)).ToList();

            if (robotsWithGivenInterface.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            robotsWithGivenInterface = robotsWithGivenInterface.OrderByDescending(r => r.BatteryLevel).ToList();
            int sum = robotsWithGivenInterface.Select(r => r.BatteryLevel).Sum();
            if (sum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);
            }

            int robotsTakingPart = 0;

            foreach(var robot in robotsWithGivenInterface)
            {
                if(robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    robotsTakingPart++;
                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(robot.BatteryLevel);
                robotsTakingPart++;

                if (totalPowerNeeded == 0)
                    break;
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsTakingPart);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var robot in robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsToFeed = robots.Models().Where(r => r.BatteryLevel < r.BatteryCapacity * 0.5).Where(r => r.Model == model).ToList();
            foreach(var robot in robotsToFeed)
            {
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, robotsToFeed.Count);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            int supplementIntefaceValue = supplement.InterfaceStandard;
            List<IRobot> robotsWithoutInterfaces = robots.Models().Where(r => r.InterfaceStandards.All(i => i != supplementIntefaceValue))
            .Where(r => r.Model == model).ToList();

            if (robotsWithoutInterfaces.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            IRobot robotToUpgrade = robotsWithoutInterfaces.First();
            robotToUpgrade.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
