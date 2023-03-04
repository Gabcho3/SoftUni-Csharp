using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        string State { get; }
        void CompleteMission();
    }
}
