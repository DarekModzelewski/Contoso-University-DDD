using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.EditInstructor
{
    internal class EditInstructorCommandHandler : ICommandHandler<EditInstructorCommand, Unit>
    {
        private readonly IInstructorRepository _instructorRepository;

        public EditInstructorCommandHandler(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<Unit> Handle(EditInstructorCommand command, CancellationToken cancellationToken)
        {
            var instructor = await  _instructorRepository.GetByIdAsync(new InstructorId(command.InstructorId));
            if (instructor == null) throw new InvalidCommandException(new List<string> { "Instructor for editing must exist." });
            instructor.Edit(command.FirstName,command.LastName,command.Address,command.PostalCode,command.City);
            return Unit.Value;
        }
    }
}
