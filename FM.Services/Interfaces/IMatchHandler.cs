using FM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Interfaces
{
    public interface IMatchHandler
    {
        Match PlayMatch(Match match);
        IEnumerable<Match> CreateMatches(League league);
    }
}
