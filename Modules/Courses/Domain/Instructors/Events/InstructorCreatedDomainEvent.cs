using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Events
{
    public class InstructorCreatedDomainEvent :DomainEventBase
    {
        public InstructorId InstructorId { get; }
        public InstructorCreatedDomainEvent(InstructorId instructorId)
        {
            InstructorId = instructorId;
        }
    }
}
