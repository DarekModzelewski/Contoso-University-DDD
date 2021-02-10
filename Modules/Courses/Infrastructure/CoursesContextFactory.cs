using ContosoUniversity.Modules.Courses.Infrastructure;
using ContosoUniversity.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Infrastructure
{
    public class CoursesContextFactory : IDesignTimeDbContextFactory<CoursesContext>
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;

        public CoursesContextFactory()
        {

        }
        public CoursesContextFactory(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }

        public CoursesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoursesContext>()
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = ConotosoDb; Trusted_Connection = True; MultipleActiveResultSets = true");// tbd

            return new CoursesContext(optionsBuilder.Options,_loggerFactory);
        }
    }
}
