using Autofac;
using ContosoUniversity.Modules.Courses.Application.Students.DomainServices;
using ContosoUniversity.Modules.Courses.Domain.Students.Services;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentUniquenessChecker>()
                .As<IStudentUniquenessChecker>()
                .InstancePerLifetimeScope();

        }
    }
}