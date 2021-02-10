using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.Modules.Courses.Domain.Instructors.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.CreateInstructor
{
    internal class CreateInstructorCommandHandler : ICommandHandler<CreateInstructorCommand, Unit>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IInstructorUniquenessChecker _instructorUniquenessChecker;

        public CreateInstructorCommandHandler(IInstructorRepository instructorRepository, IInstructorUniquenessChecker instructorUniquenessChecker)
        {
            _instructorRepository = instructorRepository;
            _instructorUniquenessChecker = instructorUniquenessChecker;
        }

        public async Task<Unit> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
        {
            var student = Instructor.Create(command.FirstName,command.LastName,command.HireDate,_instructorUniquenessChecker);
            await _instructorRepository.AddAsync(student);          
            return Unit.Value;
        }
    }
}
