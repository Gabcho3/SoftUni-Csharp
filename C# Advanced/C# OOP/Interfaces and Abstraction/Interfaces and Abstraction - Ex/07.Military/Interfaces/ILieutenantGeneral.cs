using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Interfaces
{
    public interface ILieutenantGeneral
    {
        List<IPrivate> Privates { get; set; }
    }
}
