﻿using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace FM.Core.Commands
{
    public class CreateMatchesCommand : ICommand
    {
        private ILeagueService service;

        public CreateMatchesCommand(ILeagueService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Execute(IReadOnlyList<string> args)
        {
            if (args.Count != 1)
            {
                throw new ArgumentException("League name should be entered");
            }
            var name = args[0];

            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
                $"A league's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");

            var matches = service.CreateMatches(name);
            var answer = PrintMatches(matches);
           
            return answer;
        }

        private string PrintMatches(IEnumerable<Match> matches)
        {
            StringBuilder strb = new StringBuilder();
            
            foreach (var match in matches)
            {
                strb.AppendLine($"{match.HomeTeam.Name} {match.HomeTeam.City} - {match.AwayTeam.Name} {match.AwayTeam.City}");
            }

            return strb.ToString().Trim();
        }
    }
}
