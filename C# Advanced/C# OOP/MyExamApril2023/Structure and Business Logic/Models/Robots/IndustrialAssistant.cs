using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public class IndustrialAssistant : Robot
    {
        private const int batteryCapacity = 40_000;
        private const int convertionCapacityIndex = 5_000;

        public IndustrialAssistant(string model)
            : base(model, batteryCapacity, convertionCapacityIndex) { }
    }
}
