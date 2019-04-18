using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class ShowAllLeagueMatchesCommand : ICommand
    {
        private ILeagueService service;

        public ShowAllLeagueMatchesCommand(ILeagueService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 1)
            {
                throw new ArgumentException("League name should be entered");
            }
            var name = args[0];

            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
               $"A league's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");

            var matches = service.ShowAllMatches(name);
            var answer = PrintLeagueMatches(matches);
            
            return answer;
        }

        private string PrintLeagueMatches(IEnumerable<Match> matches)
        {
            var strb = new StringBuilder();

            foreach (var match in matches)
            {
                strb.AppendLine($"{match.HomeTeam.Name} {match.HomeTeam.City} - {match.AwayTeam.Name} {match.AwayTeam.City}\n => {match.HomeTeamGoals}:{match.AwayTeamGoals}");
            }
            return strb.ToString().Trim();
        }
    }
}
