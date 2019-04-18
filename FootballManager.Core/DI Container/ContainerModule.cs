using Autofac;
using FM.Core.Contracts;
using FM.Core.Core;
using FM.Core.Core.Providers;
using FM.Core.Export;
using FM.Data.Context;
using FM.Services;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FM.Core.DI_Container
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<FMDbContext>().AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<LeagueService>().As<ILeagueService>();
            builder.RegisterType<MatchService>().As<IMatchService>();
            builder.RegisterType<PlayerService>().As<IPlayerService>();
            builder.RegisterType<TeamService>().As<ITeamService>();
            builder.RegisterType<MatchHandler>().As<IMatchHandler>();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<PDFExporter>().As<IPDFExporter>().SingleInstance();

            RegisterCommands(builder);
            base.Load(builder);
        }

        private void RegisterCommands(ContainerBuilder builder)
        {
            var commands = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.ImplementedInterfaces.Contains(typeof(ICommand)));

            foreach (var command in commands)
            {
                builder.RegisterType(command.AsType())
                    .Named<ICommand>(command.Name.ToLower().Replace("command", ""));
            }
        }
    }
}
