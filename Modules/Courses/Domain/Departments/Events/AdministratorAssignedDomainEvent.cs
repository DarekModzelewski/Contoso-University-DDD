using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Departments.Events
{
    public class AdministratorAssignedDomainEvent : DomainEventBase
    {
        public DepartmentId DepartmentId { get; }
        public InstructorId InstructorId { get; }

        public AdministratorAssignedDomainEvent(DepartmentId departmentId, InstructorId instructorId)
        {
            DepartmentId = departmentId;
            InstructorId = instructorId;
        }
    }
}
