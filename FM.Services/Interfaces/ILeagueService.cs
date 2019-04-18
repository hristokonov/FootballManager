using FM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Interfaces
{
   public interface ILeagueService
    {
        League CreateLeague(string name);
        League RetrieveLeague(string name);
        League AddTeamToLeague(string name, string city, string league);
        IEnumerable<Match> CreateMatches(string name);
        IEnumerable<Match> RetrieveLeagueMatches(League league);
        IEnumerable<Match> ShowAllMatches(string name);
        IEnumerable<Team> ShowTable(string name);
        League ResetTeams(string name);
        IEnumerable<League> ShowAllLeagues();
    }
}
