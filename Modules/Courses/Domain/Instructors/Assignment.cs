using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Instructors.Events;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors
{
    public class Assignment : Entity
    {
        internal InstructorId InstructorId { get; private set; }
        private Instructor _instructor;
        internal CourseId CourseId { get; private set; }
        private Course _course;
        private bool _isDeleted;

        public Instructor Instructor => _instructor;
        public Course Course => _course;

        private Assignment()
        {
          //EF Required
        }
        private Assignment(InstructorId instructorId,CourseId courseId)
        {
            InstructorId = instructorId;
            CourseId = courseId;

            AddDomainEvent(new InstructorAssignedToCourseDomainEvent(InstructorId, CourseId));
        }
        internal static Assignment CreateNew(InstructorId InstructorId, CourseId courseId)
        {
            return new Assignment(InstructorId, courseId);
        }
        internal void SoftDelete()
        {
            _isDeleted = true;
        }

    }
}
