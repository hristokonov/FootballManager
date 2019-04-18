using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands.ShowCommands
{
    public class ShowAllLeaguesCommand : ICommand
    {
        private ILeagueService service;

        public ShowAllLeaguesCommand(ILeagueService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            var leagues = service.ShowAllLeagues();
            var answer = PrintLeagues(leagues);
            return answer;
        }
        private string PrintLeagues(IEnumerable<League> leagues)
        {
            var sb = new StringBuilder();
            sb.AppendLine("All leagues:");
            foreach (var league in leagues)
            {
                sb.AppendLine($"{league.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
