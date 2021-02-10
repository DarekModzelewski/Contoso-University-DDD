using ContosoUniversity.Modules.Courses.Application.Configuration.Commands;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Departments.Specifications;
using ContosoUniversity.SharedKernel.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.DeleteCourse
{
    internal class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteCourseCommandHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

        public async Task<Unit> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.FindAsync(DepartmentSpecification.CourseId(new CourseId(command.CourseId)));           
            if (department == null) throw new InvalidCommandException(new List<string> { "department not exist." });
            department.DeleteCourse(new CourseId(command.CourseId));
            return Unit.Value;
        }
    }
}
