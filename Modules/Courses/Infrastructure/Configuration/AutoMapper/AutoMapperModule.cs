using Autofac;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration.AutoMapper
{
    internal class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        }
    }
}
