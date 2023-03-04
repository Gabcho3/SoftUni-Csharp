using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Interfaces
{
    public interface ISoldier
    {
        string FirstName { get; }
        string LastName { get; }
        string Id { get; }
    }
}
