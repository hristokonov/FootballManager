using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class PlayAllMatchesCommand : ICommand
    {
        private IMatchService service;

        public PlayAllMatchesCommand(IMatchService service)
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

            var matches = service.PlayAllMatches(name);
            var answer = $"Matches for League {name} \r\n";
            foreach (var match in matches)
            {
                answer += $"{match.HomeTeam.Name} {match.HomeTeam.City} - {match.AwayTeam.Name} {match.AwayTeam.City}" +
                    $" => {match.HomeTeamGoals}:{match.AwayTeamGoals}\r\n";
            }

            return answer.Trim();
        }
    }
}
