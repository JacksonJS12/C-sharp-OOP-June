﻿using CommandPattern.Core.Contracts;
using P01.CommandPattern.Common;
using System;
using System.Linq;
using System.Reflection;

namespace P01.CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdSplit = args.Split();
            string cmdName = cmdSplit[0];
            string[] cmdArgs = cmdSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command" && 
                t.GetInterfaces().Any(i => i == typeof(ICommand)));


            if (cmdType == null)
            {
                throw new InvalidOperationException(String.Format(ErrorMessages.InvalidCommandType, $"{cmdName}Command"));
            }

            object cmdIntance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType
                .GetMethods().First(m => m.Name == "Execute");

           string result = (string)executeMethod.Invoke(cmdIntance, new object[] { cmdArgs });

            return result;
        }
    }
}
