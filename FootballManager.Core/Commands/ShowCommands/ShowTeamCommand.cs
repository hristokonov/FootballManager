using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class ShowTeamCommand : ICommand
    {
        private ITeamService service;
       
        public ShowTeamCommand(ITeamService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
           
        }
        public string Execute(IReadOnlyList<string> args)
        {

            if (args.Count != 2)
            {
                throw new ArgumentException("Team has to have a name and city");
            }
            var name = args[0];
            var city = args[1];

            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, name,
                $"Team's name must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            InputValidations.ValidateLength(InputValidations.MIN_NAME, InputValidations.MAX_NAME, city,
               $"Team's city must be between {InputValidations.MIN_NAME} and {InputValidations.MAX_NAME} characters");
            
            var team = service.ShowTeam(name,city);
            var strb = new StringBuilder();
            return strb.AppendLine($"Team name: {team.Name}\r\n Team city: {team.City}\r\n Team country: { team.Country}\r\n Team owner: {team.Owner}\r\n Team manager: {team.Manager}\r\n Team budget: {team.Budget}\r\n").ToString().Trim();
        }
    }
}
