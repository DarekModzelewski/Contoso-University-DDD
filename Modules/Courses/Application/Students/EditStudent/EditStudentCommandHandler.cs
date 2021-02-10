using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Students.EditStudent
{
    internal class EditStudentCommandHandler : ICommandHandler<EditStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public EditStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(EditStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await  _studentRepository.GetByIdAsync(new StudentId(command.StudentId));

            if (student == null) throw new InvalidCommandException(new List<string> { "Student for editing must exist." });

            student.Edit(command.FirstName, command.LastName, command.EnrollementDate);

            return Unit.Value;
        }
    }
}
