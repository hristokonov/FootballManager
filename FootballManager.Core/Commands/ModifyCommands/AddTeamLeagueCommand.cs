using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace FM.Core.Commands
{
    public class AddTeamLeagueCommand : ICommand
    {
        private ILeagueService service;

        public AddTeamLeagueCommand(ILeagueService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 3)
            {
                throw new ArgumentException("Write 3 parameters separated by (;).");
            }

            var name = args[0];
            var city = args[1];
            var league = args[2];
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
               $"Team's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, city,
               $"Team's city must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, league,
               $"A league's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            service.AddTeamToLeague(name, city, league);
            return $"Team {name} {city} has been added to league {league}.";
        }
    }
}
