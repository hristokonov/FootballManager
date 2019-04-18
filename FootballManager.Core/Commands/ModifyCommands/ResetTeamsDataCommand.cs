using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class ResetTeamsDataCommand : ICommand
    {
        private ILeagueService service;

        public ResetTeamsDataCommand(ILeagueService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        public string Execute(IReadOnlyList<string> args)
        {

            if (args.Count != 1)
            {
                throw new ArgumentException("A League has to has name");
            }
            var name = args[0];

            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
               $"A league's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");

            var league = service.ResetTeams(name);

            return $"Teams data reset in league {name}";
        }
    }
}
