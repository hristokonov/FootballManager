using FM.Core.Contracts;
using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Core.Commands
{
    public class ShowPlayersToBuyCommand : ICommand
    {
        private IPlayerService service;
        

        public ShowPlayersToBuyCommand(IPlayerService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            var players = service.ShowPlayersWithoutTeam();
            var answer = PrintPlayersToBuy(players);
            
            return answer;
        }

        private string PrintPlayersToBuy(IEnumerable<Player> players)
        {
            var strb = new StringBuilder();
            if (players.Count() == 0)
            {
                strb.AppendLine($"There are no players to buy.");
            }
            foreach (var player in players)
            {
                strb.AppendLine($"{player.FirstName} {player.LastName} Rating:{player.Rating} Position:{player.Position.Name}");
            }
            return strb.ToString().Trim();
        }
    }
}
