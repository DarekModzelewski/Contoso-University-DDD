using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.CreateDepartment
{
    internal class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Unit> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = Department.Create(command.Name, command.Budget,command.Currency, command.StartDate);
            await _departmentRepository.AddAsync(department);          
            return Unit.Value;
        }
    }
}
