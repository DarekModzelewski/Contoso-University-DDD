using System.Threading.Tasks;
using Autofac;
using ContosoUniversity.Modules.courses.Infrastructure.Configuration;
using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.Modules.Courses.Infrastructure.Configuration.Processing;
using MediatR;

namespace ContosoUniversity.Modules.Courses.Infrastructure
{
    public class CoursesModule : ICoursesModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = CoursesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}