using Autofac;
using FM.Core.Contracts;
using FM.Core.Core;
using FM.Core.DI_Container;
using System;
using System.ComponentModel;
using System.Reflection;

namespace FM.Core
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //  builder.RegisterModule<Container>();
            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(ContainerModule)));
            var container = builder.Build();
            var engine = container.Resolve<IEngine>();

            engine.Run();
        }
    }
}
