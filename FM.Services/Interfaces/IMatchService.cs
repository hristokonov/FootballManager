using FM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FM.Services.Interfaces
{
   public interface IMatchService
    {
        Stadium CreateStadium(string name, string city, string country, int capacity);
        Stadium RetrieveStadium(string name, string city);
        IEnumerable<Match> PlayAllMatches(string name);
        void DeleteAllMatches();
    }
}
