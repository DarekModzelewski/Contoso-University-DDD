using System;
using System.Threading;
using System.Threading.Tasks;
using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.SharedKernel.Infrastructure;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
        where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CoursesContext _coursesContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(
            ICommandHandler<T, TResult> decorated,
            IUnitOfWork unitOfWork,
            CoursesContext coursesContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _coursesContext = coursesContext;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await _decorated.Handle(command, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}