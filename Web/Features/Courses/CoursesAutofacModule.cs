using Autofac;
using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.Modules.Courses.Infrastructure;

namespace ContosoUniversity.Web.Features.Courses
{
    public class CoursesAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CoursesModule>()
                .As<ICoursesModule>()
                .InstancePerLifetimeScope();

        }
    }
}