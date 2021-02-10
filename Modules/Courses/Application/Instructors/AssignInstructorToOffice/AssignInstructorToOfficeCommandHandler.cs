using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.AssignInstructorToOffice
{
    internal class AssignInstructorToOfficeCommandHandler : ICommandHandler<AssignInstructorToOfficeCommand, Unit>
    {
        private readonly IInstructorRepository _instructorRepository;

        public AssignInstructorToOfficeCommandHandler(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<Unit> Handle(AssignInstructorToOfficeCommand command, CancellationToken cancellationToken)
        {
            var instructor = await  _instructorRepository.GetByIdAsync(new InstructorId(command.InstructorId));
            if (instructor == null) throw new InvalidCommandException(new List<string> { "Instructor for assigning must exist." });
            instructor.AssignToOffice(command.Address,command.PostalCode,command.City);
            return Unit.Value;
        }
    }
}
