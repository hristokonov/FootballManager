using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class CreateStadiumCommand : ICommand
    {
        private IMatchService service;

        public CreateStadiumCommand(IMatchService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 4)
            {
                throw new ArgumentException("A stadium has to have a name, city, country and capacity.");
            }

            var name = args[0];
            var city = args[1];
            var country = args[2];
            var capacity = InputValidations.ValidateRatingConversion(InputValidations.MIN_STADIUM, InputValidations.MAX_STADIUM, args[3],
                "Invalid Stadium Capacity");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
              $"A stadium name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, city,
               $"A city name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, country,
               $"A country name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");

            service.CreateStadium(name, city, country, capacity);
            return $"Stadium {name} in {city} has been created.";
        }
    }
}
