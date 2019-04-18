using FM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Interfaces
{
   public interface IPlayerService 
    {
        Player CreatePlayer(string firstName, string lastName, string nationality, int rating, int position);
        Player RetirePlayer(string firstName, string lastName);
        Player RetrievePlayer(string firstName, string lastName);
        IEnumerable<Player>ShowPlayers();
       // IEnumerable<Player> ShowPlayersToBuy();
        IEnumerable<Player> ShowTeamPlayers(string name, string city);
        IEnumerable<Player> RetrieveTeamPlayers(Team team);
        IEnumerable<Player> ShowPlayersWithoutTeam();
    }
}
