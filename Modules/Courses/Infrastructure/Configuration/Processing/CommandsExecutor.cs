using System.Threading.Tasks;
using Autofac;
using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.Modules.courses.Infrastructure.Configuration;
using MediatR;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration.Processing
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            using (var scope = CoursesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = CoursesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}