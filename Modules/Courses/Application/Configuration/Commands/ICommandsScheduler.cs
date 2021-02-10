using ContosoUniversity.Modules.Courses.Application.Contracts;
using System.Threading.Tasks;


namespace ContosoUniversity.Modules.Courses.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
    }
}