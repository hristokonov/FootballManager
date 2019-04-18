using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class CreatePlayerCommand : ICommand
    {

        private IPlayerService service;

        public CreatePlayerCommand(IPlayerService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 5)
            {
                throw new ArgumentException("A player has to have a firstname,lastname,nationality,rating and positionId");
            }
            var firstName = args[0];
            var lastName = args[1];
            var nationality = args[2];
            var rating = InputValidations.ValidateRatingConversion(InputValidations.MIN_RATING, InputValidations.MAX_RATING, args[3],
                "Invalid rating");
            var position = InputValidations.ValidateRatingConversion(InputValidations.MIN_POSITION, InputValidations.MAX_POSITION, args[4],
                "Invalid position");
            
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, firstName,
               $"A player's firstname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, lastName,
               $"A player's lastname must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, nationality,
            $"A nationality must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");

            var player = service.CreatePlayer(firstName, lastName, nationality, rating, position);
            return $"Created player {firstName} {lastName}";
        }
    }
}
