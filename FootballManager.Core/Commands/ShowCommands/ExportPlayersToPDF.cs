using FM.Core.Contracts;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Core.Commands
{
   public class ExportPlayersToPDF : ICommand
    {
        private IPlayerService service;
        private IPDFExporter exporter;
        public ExportPlayersToPDF(IPlayerService service, IPDFExporter exporter)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.exporter = exporter;
        }
        public string Execute(IReadOnlyList<string> args)
        {
            var players = service.ShowPlayers();
            if (players.Count() == 0)
            {
                return "There are no players to export";
            }
            this.exporter.GeneratePlayersPDF(players);

            return "Created PDF Report";
        }
    }
}
