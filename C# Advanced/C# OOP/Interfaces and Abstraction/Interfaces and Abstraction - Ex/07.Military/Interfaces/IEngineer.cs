using _07.Military.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Interfaces
{
    public interface IEngineer
    {
        List<Repair> Repairs { get; set; }
    }
}
