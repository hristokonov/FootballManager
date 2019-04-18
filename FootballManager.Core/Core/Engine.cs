using FM.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Core
{
    public class Engine : IEngine
    {
        public IReader Reader { get; }

        public IWriter Writer { get; }

        public ICommandProcessor Processor { get; }

        public Engine(IReader reader, IWriter writer, ICommandProcessor processor)
        {
            this.Reader = reader ?? throw new ArgumentNullException(nameof(reader));
            this.Writer = writer ?? throw new ArgumentNullException(nameof(writer));
            this.Processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }


        public void Run()
        {
            while (true)
            {
                var input = this.Reader.ReadLine();
                if (input=="end")
                {
                    Writer.WriteLine("Have a nice day!");
                    break;
                }
                var output = this.Processor.ProcessSingleCommand(input);
                this.Writer.WriteLine(output);
            }
        }
    }
}
