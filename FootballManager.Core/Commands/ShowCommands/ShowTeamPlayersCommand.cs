using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class ShowTeamPlayersCommand : ICommand
    {
        private IPlayerService service;
        
        public ShowTeamPlayersCommand(IPlayerService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 2)
            {
                throw new ArgumentException("Team has to have a name and city");
            }
            var name = args[0];
            var city = args[1];
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
               $"Team's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, city,
               $"Team's city must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");

            var team = service.ShowTeamPlayers(name, city);
            var answer = PrintShowTeamPlayers(team);

            return answer;
        }

        private string PrintShowTeamPlayers(IEnumerable<Player> players)
        {
            StringBuilder strb = new StringBuilder();
            foreach (var player in players)
            {
                strb.AppendLine($"{player.FirstName} {player.LastName} Rating:{player.Rating:f0} Position:{player.Position.Name}");
            }

            return strb.ToString().Trim();
        }
    }
}
