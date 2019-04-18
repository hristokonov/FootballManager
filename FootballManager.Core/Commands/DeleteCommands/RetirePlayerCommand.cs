using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class RetirePlayerCommand : ICommand
    {
        private IPlayerService service;

        public RetirePlayerCommand(IPlayerService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }


        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 2)
            {
                throw new ArgumentException("A player has to have a firstname,lastname,nationality,rating and positionId");
            }
            var firstName = args[0];
            var lastName = args[1];
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, firstName,
               $"A player's firstname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, lastName,
               $"A player's lastname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");


            var player = service.RetirePlayer(firstName, lastName);
            return $"Player  {player.FirstName} {player.LastName} has retired";
        }
    }
}
