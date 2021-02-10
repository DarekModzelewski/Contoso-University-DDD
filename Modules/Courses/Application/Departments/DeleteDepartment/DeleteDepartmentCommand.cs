using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.DeleteDepartment
{
    public class DeleteDepartmentCommand : CommandBase<Unit>
    {
        public Guid DepartmentId { get; }

        public DeleteDepartmentCommand(Guid departmentId) => DepartmentId = departmentId;

    }
   
}
