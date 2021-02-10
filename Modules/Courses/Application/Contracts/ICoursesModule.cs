using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Contracts
{
    public interface ICoursesModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}