﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Interfaces
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
