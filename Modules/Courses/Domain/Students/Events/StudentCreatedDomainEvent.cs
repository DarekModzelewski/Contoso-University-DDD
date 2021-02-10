using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Students.Events
{
    public class StudentCreatedDomainEvent : DomainEventBase
    {
        public StudentId StudentId { get; }
        public StudentCreatedDomainEvent(StudentId studentId)
        {
            StudentId = studentId;
        }
    }
}