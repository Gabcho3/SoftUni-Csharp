﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    internal class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello, {args[0]}";
    }
}
