using FM.Core.Contracts;
using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Core.Commands
{
    public class ShowPlayersCommand : ICommand
    {
        private IPlayerService service;

        public ShowPlayersCommand(IPlayerService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            var players = service.ShowPlayers();

            var answer = PrintPlayers(players);
            
            return answer;
        }

        private string PrintPlayers(IEnumerable<Player> players)
        {
           
            StringBuilder strb = new StringBuilder();
            foreach (var player in players)
            {
                strb.AppendLine($"{player.FirstName} {player.LastName} Rating:{player.Rating} Position:{player.Position.Name}");
            }

            return strb.ToString().Trim();
        }
    }
}
