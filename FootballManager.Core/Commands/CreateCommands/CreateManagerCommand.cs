using FM.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace FM.Core.Commands
{
    public class CreateManagerCommand : ICommand
    {
        private IManagerService service;

        public CreateManagerCommand(IManagerService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 3)
            {
                throw new ArgumentException( "A manager has to have a firstname,lastname and nationality");
            }
            var firstName = args[0];
            var lastName = args[1];
            var nationality = args[2];
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, firstName,
              $"A manager's firstname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, lastName,
              $"A manager's lastname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, nationality,
              $"A nationality must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            
            var player = service.CreateManager(firstName, lastName, nationality);
            return $"Created manager {firstName} {lastName}";
        }
    }
}
