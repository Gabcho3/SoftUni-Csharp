using _07.Military.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Interfaces
{
    public interface ICommando
    {
        List<Mission> Missions { get; set; }
    }
}
