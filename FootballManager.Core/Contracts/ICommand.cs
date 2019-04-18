using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core
{
    public interface ICommand
    {
        string Execute(IReadOnlyList<string> args);
    }
}
