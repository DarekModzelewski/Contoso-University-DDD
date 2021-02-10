using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.DeleteDepartment
{
    internal class DeleteDepartmentCommandHandler : ICommandHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = await  _departmentRepository.GetByIdAsync(new DepartmentId(command.DepartmentId));
            if (department == null) throw new InvalidCommandException(new List<string> { "Department for deleting must exist." });
            department.SoftDelete();
            return Unit.Value;
        }
    }
}
