using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FM.Core.Commands
{
    public class HelpCommand : ICommand
    {
        public string Execute(IReadOnlyList<string> args)
        {
            string answer = "Available commands:\r\n";
            var commands = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.ImplementedInterfaces.Contains(typeof(ICommand)));
            
            foreach (var command in commands)
            {
                var name = command.Name.ToLower().Replace("command", "");
                if (name!="help")
                {
                    answer +="- " + name + "\r\n";
                }
            }
            return answer.Trim();
        }
    }
}
