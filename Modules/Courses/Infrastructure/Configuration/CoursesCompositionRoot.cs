using Autofac;

namespace ContosoUniversity.Modules.courses.Infrastructure.Configuration
{
    internal static class CoursesCompositionRoot
    {
        private static IContainer _container;

        internal static void SetContainer(IContainer container)
        {
            _container = container;
        }

        internal static ILifetimeScope BeginLifetimeScope()
        {
            return _container.BeginLifetimeScope();
        }
    }

}