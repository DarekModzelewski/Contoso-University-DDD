using System;
using Autofac;
using ContosoUniversity.Modules.courses.Infrastructure.Configuration;
using ContosoUniversity.Modules.Courses.Infrastructure.Configuration.DataAccess;
using ContosoUniversity.Modules.Courses.Infrastructure.Configuration.Logging;
using ContosoUniversity.Modules.Courses.Infrastructure.Configuration.Processing;
using ContosoUniversity.Modules.Meetings.Infrastructure.Configuration.Mediation;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;
using ContosoUniversity.Modules.Courses.Infrastructure.Configuration.AutoMapper;
using ContosoUniversity.Modules.Courses.Infrastructure.Domain;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration
{
    public class CoursesStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString, ILogger logger)
        {
            var moduleLogger = logger.ForContext("Module", "Courses");
            ConfigureCompositionRoot(connectionString,moduleLogger);
        }

        private static void ConfigureCompositionRoot(string connectionString,ILogger logger)
        {
            var loggerFactory = new SerilogLoggerFactory(logger);           
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Courses")));         
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new AutoMapperModule());      
            _container = containerBuilder.Build();

           // var dbInitializer = _container.Resolve<DbInitializer>();
           // dbInitializer.Initialize();

            CoursesCompositionRoot.SetContainer(_container);
        }
    }
}