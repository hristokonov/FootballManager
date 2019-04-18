using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Commands
{
    public class DeleteMatchesCommand : ICommand
    {
        private IMatchService service;
        public DeleteMatchesCommand(IMatchService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        public string Execute(IReadOnlyList<string> args)
        {
            service.DeleteAllMatches();

            return "All matches deleted!";
        }
    }
}
