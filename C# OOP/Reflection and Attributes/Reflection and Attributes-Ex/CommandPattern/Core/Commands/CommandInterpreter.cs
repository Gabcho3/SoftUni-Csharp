using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Commands
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = arguments[0];

            string[] commandArgs = arguments.Skip(1).ToArray();

            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(a => a.Name == $"{command}Command");
            ICommand commandInstance = Activator.CreateInstance(type) as ICommand;

            return commandInstance.Execute(commandArgs);
        }
    }
}
