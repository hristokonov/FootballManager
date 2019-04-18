using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandName);
    }
}
