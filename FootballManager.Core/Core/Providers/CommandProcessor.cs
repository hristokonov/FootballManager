using FM.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Core.Core.Providers
{
   public class CommandProcessor : ICommandProcessor
    {

        public ICommandParser Parser { get; }

        public CommandProcessor(ICommandParser parser)
        {
            this.Parser = parser;
        }
        public string ProcessSingleCommand(string input)
        {

            if (input==null || input=="")
            {
                return ("Please enter a command");
            }
            var lineParameters = input.Trim().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var commandName = lineParameters[0];
            var parameters = lineParameters.Skip(1);
          
            try
            {
              var  command = this.Parser.ParseCommand(commandName);
                if (command != null)
                {
                    var result = command.Execute(parameters.ToList());
                    return result;
                }
                else
                {
                    return $"Invalid command!";
                }
            }
            catch (Exception ex) when (ex is DbUpdateException)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                return $"Sql error occurred: {ex.Message}";
            }
            catch(Exception ex)
            {
                return $"{ex.Message}";
            }
        }
    }
}
