using ContosoUniversity.SharedKernel.Domain;
using ContosoUniversity.Modules.Courses.Domain.Students.Events;
using ContosoUniversity.Modules.Courses.Domain.Departments;

namespace ContosoUniversity.Modules.Courses.Domain.Students
{
    public class Enrollment : Entity
    {
        internal CourseId CourseId { get; private set; }
        private Course _course;

        internal StudentId StudentId { get; private set; }
        private Student _student;

        private Grade _grade;
        private bool _isDeleted;

        public Course Course => _course;
        public Student Student => _student;
        public Grade Grade => _grade;

        private Enrollment()
        {
            //EF required
        }

        private Enrollment(StudentId studentId,CourseId courseId)
        {          
            StudentId = studentId;
            CourseId = courseId;

            AddDomainEvent(new StudentEnrolledToCourseDomainEvent(StudentId, CourseId));
        }

        internal static Enrollment CreateNew(StudentId studentId, CourseId courseId)
        {
            return new Enrollment(studentId,courseId);
        }

        internal void AddGrade(Grade grade)
        {
            _grade = grade;
        }
        internal void SoftDelete()
        {
            _isDeleted = true;
        }

    }
}
