using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class BuyPlayerCommand : ICommand
    {
        private ITeamService service;

        public BuyPlayerCommand(ITeamService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 4)
            {
                throw new ArgumentException( "A has has to have a name,city,country,owner");
            }
            var name = args[0];
            var city = args[1];
            var firstName = args[2];
            var lastName = args[3];
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
                $"Team's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, city,
               $"Team's city must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, firstName,
               $"A player's firstname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, lastName,
               $"A player's lastname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
          

            var team = service.BuyPlayer(name, city, firstName, lastName);
            
                return $"Team {team.Name} {team.City} has bought {firstName} {lastName}";
            
        }
    }
}
