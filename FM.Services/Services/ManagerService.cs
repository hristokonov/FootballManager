using FM.Data.Context;
using FM.Data.Models;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Services
{
    public class ManagerService: IManagerService
    {
        private readonly FMDbContext context;
        private readonly ITeamService teamService;
        public ManagerService(FMDbContext context, ITeamService teamService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.teamService = teamService;
        }
        public Manager CreateManager(string firstName, string lastName, string nationality)
        {
            var managerexist = RetrieveManager(firstName, lastName);
            Validations.ValidateAlreadyExists(managerexist, "Manager already exists");

            var manager = new Manager
            {
                FirstName = firstName,
                LastName = lastName,
                Nationality = nationality
            };
            context.Managers.Add(manager);
            context.SaveChanges();
            return manager;

        }
        public Manager RetrieveManager(string firstName, string lastName)
        {
            var manager = this.context.Managers
                .FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
            return manager;
        }

        public Manager HireManager(string firstName, string lastName, string name, string city)
        {
            var manager = RetrieveManager(firstName, lastName);
            Validations.ValidateDoesntExists(manager, "Manager doesn't exists");

            var team = teamService.RetrieveTeam(name, city);
            Validations.ValidateDoesntExists(team, "Team doesn't exists");

            manager.TeamId = team.Id;
            context.SaveChanges();
            return manager;
        }
        public Manager FireManager(string firstName, string lastName, string name, string city)
        {
            var manager = RetrieveManager(firstName, lastName);
            Validations.ValidateDoesntExists(manager, "Manager doesn't exists");

            var team = teamService.RetrieveTeam(name, city);
            Validations.ValidateDoesntExists(team, "Team doesn't exists");

            manager.TeamId = null;
            team.Manager = null;
            context.SaveChanges();
            return manager;
        }
    }
}
