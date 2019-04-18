using FM.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Core.Providers
{
   public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
