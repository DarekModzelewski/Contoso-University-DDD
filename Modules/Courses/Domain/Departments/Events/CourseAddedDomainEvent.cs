using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Departments.Events
{
    public class CourseAddedDomainEvent : DomainEventBase
    {
        public CourseId CourseId { get; }
        public CourseAddedDomainEvent(CourseId courseId)
        {
            CourseId = courseId;
        }
    }
}
