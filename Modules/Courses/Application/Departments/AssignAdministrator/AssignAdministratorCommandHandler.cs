using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.AssignAdministrator
{
    internal class AssignAdministratorCommandHandler : ICommandHandler<AssignAdministratorCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public AssignAdministratorCommandHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

        public async Task<Unit> Handle(AssignAdministratorCommand command, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(new DepartmentId(command.DepartmentId));
            if (department == null) throw new InvalidCommandException(new List<string> { "department must exist." });
            department.AssignAdministrator(new InstructorId(command.InstructorId));
            return Unit.Value;
        }
    }
}
