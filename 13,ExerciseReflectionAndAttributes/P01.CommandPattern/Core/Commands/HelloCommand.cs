﻿using CommandPattern.Core.Contracts;
namespace P01.CommandPattern.Core.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}