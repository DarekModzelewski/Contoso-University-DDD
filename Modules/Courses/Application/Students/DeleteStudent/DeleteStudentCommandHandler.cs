using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Students.DeleteStudent
{
    internal class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await  _studentRepository.GetByIdAsync(new StudentId(command.StudentId));
            if (student == null) throw new InvalidCommandException(new List<string> { "Student for deleting must exist." });
            student.SoftDelete();
            return Unit.Value;
        }
    }
}
