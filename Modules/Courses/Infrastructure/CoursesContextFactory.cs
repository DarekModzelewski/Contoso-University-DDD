using ContosoUniversity.Modules.Courses.Infrastructure;
using ContosoUniversity.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Infrastructure
{
    public class CoursesContextFactory : IDesignTimeDbContextFactory<CoursesContext>
    {
        public CoursesContextFactory()
        {
        }

        public CoursesContext CreateDbContext(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: false)
                .Build();
            
            var optionsBuilder = new DbContextOptionsBuilder<CoursesContext>()
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new CoursesContext(optionsBuilder.Options);
        }
    }
}
