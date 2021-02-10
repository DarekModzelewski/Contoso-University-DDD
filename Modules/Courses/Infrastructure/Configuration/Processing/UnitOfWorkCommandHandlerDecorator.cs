using System;
using System.Threading;
using System.Threading.Tasks;
using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.SharedKernel.Infrastructure;
using MediatR;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly ICommandHandler<T> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CoursesContext _coursesContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork,
            CoursesContext coursesContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _coursesContext = coursesContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await _decorated.Handle(command, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}