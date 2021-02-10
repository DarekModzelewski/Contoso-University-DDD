using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.Modules.Courses.Domain.Students.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Students.CreateStudent
{
    internal class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentUniquenessChecker _studentUniquenessChecker;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IStudentUniquenessChecker studentUniquenessChecker)
        {
            _studentRepository = studentRepository;
            _studentUniquenessChecker = studentUniquenessChecker;
        }

        public async Task<Unit> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = Student.Create(command.FirstName, command.LastName, command.EnrollementDate,_studentUniquenessChecker);
            await _studentRepository.AddAsync(student);          
            return Unit.Value;
        }
    }
}
