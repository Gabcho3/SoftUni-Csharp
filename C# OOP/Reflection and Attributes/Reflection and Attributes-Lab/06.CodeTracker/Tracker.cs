using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods((BindingFlags)60);

            foreach (MethodInfo method in methods)
            {
                AuthorAttribute[] attributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();

                foreach (AuthorAttribute authorAttribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                }
            }
        }
    }
}
