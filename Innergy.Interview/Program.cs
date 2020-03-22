using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Autofac;

namespace Innergy.Interview
{
    public class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var input = args[0];
                var output = args[1];

                using var container = ConfigureContainer();
                using var scope = container.BeginLifetimeScope();
                
                var etlService = scope.Resolve<IEtlService>();
                etlService.Process(input, output);

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return 0;
        }


        public static ContainerBuilder GetBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder;

        }

        public static IContainer ConfigureContainer()
        {
            var builder = GetBuilder();

            var container = builder.Build();

            return container;
        }
    }
}
