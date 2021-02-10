using System.Reflection;
using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;


namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}