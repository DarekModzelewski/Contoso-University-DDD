using MediatR;

namespace ContosoUniversity.Modules.Courses.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}