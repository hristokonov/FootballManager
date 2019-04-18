using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Core.Commands
{
    public class ShowTableCommand : ICommand
    {
        private ILeagueService service;

        public ShowTableCommand(ILeagueService service)
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

            var teams = service.ShowTable(name);
           
            var answer = $"League Table {name} \r\n";
             answer += $"  Team Name      GS-GC Points\r\n";
            var count = 1;
            foreach (var team in teams.OrderByDescending(t=>t.Points)
                .ThenByDescending(t=>t.GoalDifference)
                .ThenByDescending(t=>t.GoalsScored))
            {
                answer += $"{count}.{team.Name} {team.City} - {team.GoalsScored}-{team.GoalsConcede}  {team.Points}\r\n";
                count++;
            }

            return answer.Trim();
        }


    }
}
