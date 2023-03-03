using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public interface ISmartPhone
    {
        void Calling(string number);
        void Browsing(string url);
    }
}
