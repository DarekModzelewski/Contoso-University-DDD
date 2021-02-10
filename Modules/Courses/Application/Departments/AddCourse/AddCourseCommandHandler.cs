using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.AddCourse
{
    internal class AddCourseCommandHandler : ICommandHandler<AddCourseCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public AddCourseCommandHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

        public async Task<Unit> Handle(AddCourseCommand command, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(new DepartmentId(command.DepartmentId));
            if (department == null) throw new InvalidCommandException(new List<string> { "department must exist." });
            department.AddNewCourse(command.Title,command.Credits);
            return Unit.Value;
        }
    }
}
