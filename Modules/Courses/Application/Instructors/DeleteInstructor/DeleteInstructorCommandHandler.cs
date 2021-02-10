using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.DeleteInstructor
{
    internal class DeleteInstructorCommandHandler : ICommandHandler<DeleteInstructorCommand, Unit>
    {
        private readonly IInstructorRepository _instructorRepository;

        public DeleteInstructorCommandHandler(IInstructorRepository instructorRepository) => _instructorRepository = instructorRepository;

        public async Task<Unit> Handle(DeleteInstructorCommand command, CancellationToken cancellationToken)
        {
            var instructor = await  _instructorRepository.GetByIdAsync(new InstructorId(command.InstructorId));
            if (instructor == null) throw new InvalidCommandException(new List<string> { "Instructor for deleting must exist." });
            instructor.SoftDelete();
            return Unit.Value;
        }
    }
}
