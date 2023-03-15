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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields();
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields.Where(f => f.IsPublic))
            {
                sb.Append($"{field.Name} must be private!" + Environment.NewLine);
            }

            foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.Append($"{method.Name} have to be public!" + Environment.NewLine);
            }

            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.Append($"{method.Name} have to be private!" + Environment.NewLine);
            }

            return sb.ToString().Trim();
        }
    }
}
