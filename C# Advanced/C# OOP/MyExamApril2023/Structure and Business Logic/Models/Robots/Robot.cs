using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private List<int> intefaceStandards;
        private int batteryLevel;

        public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            intefaceStandards = new List<int>();
            batteryLevel = batteryCapacity;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel => batteryLevel;

        public int ConvertionCapacityIndex { get; }

        public IReadOnlyCollection<int> InterfaceStandards => intefaceStandards;

        public void Eating(int minutes)
        {
            for(int minute = 0;  minute < minutes; minute++)
            {
                batteryLevel += ConvertionCapacityIndex;

                if (batteryLevel == batteryCapacity)
                {
                    return;
                }
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (batteryLevel < consumedEnergy)
            {
                return false;
            }

            batteryLevel -= consumedEnergy;
            return true;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            int intefaceStandard = supplement.InterfaceStandard;
            intefaceStandards.Add(intefaceStandard);
            batteryCapacity -= supplement.BatteryUsage;
            batteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.Append("--Supplements installed: ");
            sb.Append(intefaceStandards.Count > 0 ? string.Join(" ", InterfaceStandards) : "none");

            return sb.ToString().TrimEnd();
        }
    }
}
