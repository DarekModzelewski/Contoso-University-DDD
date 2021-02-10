using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.AssignAdministrator
{
    public class AssignAdministratorCommand : CommandBase<Unit>
    {
        public Guid DepartmentId { get; }
        public Guid InstructorId { get; }
        public AssignAdministratorCommand(Guid departmentId, Guid instructorId)
        {
            DepartmentId = departmentId;
            InstructorId = instructorId;          
        }
    }
}
