using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class CreateTeamCommand : ICommand
    {

        private ITeamService service;

        public CreateTeamCommand(ITeamService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {


            if (args.Count != 4)
            {
                throw new ArgumentException("Team has to have a name,city,country,owner");
            }
            var name = args[0];
            var city = args[1];
            var country = args[2];
            var owner = args[3];

            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
              $"Team's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, city,
               $"Team's city must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, country,
              $"A country must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, owner,
              $"An owner must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
           

            var team = service.CreateTeam(name, city, country, owner);
            return $"Created team {name} {city}";

            
        }
    }
}
