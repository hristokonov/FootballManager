using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class HireManagerCommand : ICommand
    {

       
        private IManagerService service;
        public HireManagerCommand(IManagerService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 4)
            {
                throw new ArgumentException("The command has to have a firstname,lastname,team name and city");
            }
            var firstName = args[0];
            var lastName = args[1];
            var name = args[2];
            var city = args[3];
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, firstName,
              $"A player's firstname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, lastName,
               $"A player's lastname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
             $"Team's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, city,
               $"Team's city must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");

            var manager = service.HireManager(firstName, lastName, name, city);
            return $"Team {name} {city} hired {manager.FirstName} {manager.LastName}";

        }
    }
}
