using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Contracts
{
    public interface IWriter
    {
        void WriteLine(object output);
    }
}
