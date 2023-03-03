using _04.BorderControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IBirthable : IIdentifiable
    {
        string Birthdate { get; }
    }
}
