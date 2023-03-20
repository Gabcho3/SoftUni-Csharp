using Stealer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            
            sb.Append($"All Private Methods of Class: {type.FullName}");
            sb.Append(Environment.NewLine + $"Base Class: {type.BaseType.Name}");

            foreach (MethodInfo method in privateMethods )
            {
                sb.Append(Environment.NewLine + method.Name);
            }

            return sb.ToString();
        }
    }
}
