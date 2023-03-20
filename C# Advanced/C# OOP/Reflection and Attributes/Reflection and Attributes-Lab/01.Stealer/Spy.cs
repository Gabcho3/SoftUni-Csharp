using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields((BindingFlags)60);
            Object classInstance = Activator.CreateInstance(type);

            sb.Append($"Class under investigation: {className}");
            foreach (FieldInfo field in fields.Where(f => fieldNames.Contains(f.Name)))
            {
                sb.Append(Environment.NewLine + $"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString();
        }
    }
}
