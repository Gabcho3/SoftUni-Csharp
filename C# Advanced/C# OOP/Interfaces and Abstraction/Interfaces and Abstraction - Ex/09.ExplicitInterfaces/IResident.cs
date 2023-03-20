using System;
using System.Collections.Generic;
using System.Text;

namespace _09.Explicit
{
    public interface IResident
    {
        string Country { get; }

        string GetName();
    }
}
