using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Suppliments
{
    public abstract class Supplement : ISupplement
    {
        public Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        public int InterfaceStandard { get; }

        public int BatteryUsage { get; }
    }
}
