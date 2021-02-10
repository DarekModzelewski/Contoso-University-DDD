using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;

namespace ContosoUniversity.Modules.Courses.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}