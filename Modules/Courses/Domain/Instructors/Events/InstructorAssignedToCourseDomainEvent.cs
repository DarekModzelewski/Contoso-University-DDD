using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Domain;


namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Events
{
    public class InstructorAssignedToCourseDomainEvent : DomainEventBase
    {
        public InstructorId InstructorId { get; }
        public CourseId CourseId { get; }
        public InstructorAssignedToCourseDomainEvent(InstructorId instructorId,CourseId courseId)
        {
            InstructorId = instructorId;
            CourseId = courseId;          
        }
    }
}
