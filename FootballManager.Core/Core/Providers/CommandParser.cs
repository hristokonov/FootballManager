using Autofac;
using FM.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ILifetimeScope scope;

        public CommandParser(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public ICommand ParseCommand(string commandName)
        {
            try
            {
                return scope.ResolveNamed<ICommand>(commandName.ToLower());
            }
            catch (Exception ex)
            {
                return null;
               // return ex.Message; ;

            }
        }
    }
}
