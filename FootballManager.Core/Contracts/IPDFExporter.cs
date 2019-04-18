using FM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Contracts
{
    public interface IPDFExporter
    {
        void GeneratePlayersPDF(IEnumerable<Player> players);
    }
}
