using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Departments.Specifications;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.EditCourse
{
    internal class EditCourseCommandHandler : ICommandHandler<EditCourseCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public EditCourseCommandHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

        public async Task<Unit> Handle(EditCourseCommand command, CancellationToken cancellationToken)
        {
            var department = await  _departmentRepository.FindAsync(DepartmentSpecification.CourseId(new CourseId(command.CourseId)));
            if (department == null) throw new InvalidCommandException(new List<string> { "Department not exist." });
            department.EditCourse(new CourseId(command.CourseId), command.Title, command.Credits);
            return Unit.Value;
        }
    }
}
