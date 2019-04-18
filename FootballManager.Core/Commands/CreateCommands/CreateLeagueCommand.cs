using FM.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace FM.Core.Commands
{
    public class CreateLeagueCommand : ICommand
    {
        private ILeagueService service;

        public CreateLeagueCommand(ILeagueService service)
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

            var league= service.CreateLeague(name);
            return $"League {league.Name} has been created.";
        }
    }
}
