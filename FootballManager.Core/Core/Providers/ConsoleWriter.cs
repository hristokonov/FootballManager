using FM.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Core.Providers
{
   public class ConsoleWriter : IWriter
    {
        public void WriteLine(object output)
        {
            Console.WriteLine(output);
        }
    }
}
