using RobotService.Models.Suppliments;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Supplements
{
    public class LaserRadar : Supplement
    {
        private const int interfaceStandard = 20082;
        private const int batteryUsage = 5_000;

        public LaserRadar() : base(interfaceStandard, batteryUsage) { }
    }
}
