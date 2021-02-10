using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.EditDepartment
{
    internal class EditDepartmentCommandHandler : ICommandHandler<EditDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public EditDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Unit> Handle(EditDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = await  _departmentRepository.GetByIdAsync(new DepartmentId(command.DepartmentId));
            if (department == null) throw new InvalidCommandException(new List<string> { "Department for editing must exist." });
            department.Edit(command.Name,command.Budget,command.Currency,command.StartDate);
            return Unit.Value;
        }
    }
}
