using Autofac;
using ContosoUniversity.Modules.Infrastructure;
using ContosoUniversity.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration.DataAccess
{
    internal class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;
        private readonly ILoggerFactory _loggerFactory;

        internal DataAccessModule(string databaseConnectionString, ILoggerFactory loggerFactory)
        {
            _databaseConnectionString = databaseConnectionString;
            _loggerFactory = loggerFactory;
        }
        protected override void Load(ContainerBuilder builder) 
        {            
            builder.Register(c =>
            {
               return new CoursesContextFactory(_databaseConnectionString, _loggerFactory);
            }).AsSelf()
              .InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<CoursesContext>();
                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                dbContextOptionsBuilder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                return new CoursesContext(dbContextOptionsBuilder.Options, _loggerFactory);
            }).AsSelf()
              .As<DbContext>()
              .InstancePerLifetimeScope();
                      
          //  builder.RegisterType<DbInitializer>().AsSelf().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(CoursesContext).Assembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }
      
    }
}