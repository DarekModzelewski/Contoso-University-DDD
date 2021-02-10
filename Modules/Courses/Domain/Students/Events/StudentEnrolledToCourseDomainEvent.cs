using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Students.Events
{
    public class StudentEnrolledToCourseDomainEvent : DomainEventBase
    {
        public StudentId StudentId { get; }
        public CourseId CourseId { get; }
        public StudentEnrolledToCourseDomainEvent(StudentId studentId, CourseId courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}