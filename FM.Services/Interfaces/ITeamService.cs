using FM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Interfaces
{
   public interface ITeamService 
    {
        Team CreateTeam(string name,string city,string country,string owner);
        Team BuyPlayer(string name, string city, string firstName, string lastName);
        Team RetrieveTeam(string name, string city);
        int RetrieveTeamRatings(Team team);
        List<Team> RetrieveLeagueTeams(League league);
        Team ShowTeam(string name, string city);
    }
}
