using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public class DomesticAssistant : Robot
    {
        private const int batteryCapacity = 20_000;
        private const int convertionCapacityIndex = 2_000;

        public DomesticAssistant(string model)
            :base(model, batteryCapacity, convertionCapacityIndex) { }
    }
}
