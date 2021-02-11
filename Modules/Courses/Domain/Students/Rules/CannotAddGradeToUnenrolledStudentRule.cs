using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Domain.Students.Rules
{
    internal class CannotAddGradeToUnenrolledStudentRule :IDomainRule
    {
        private readonly StudentId _studentId;
        private readonly CourseId _courseId;
        private readonly List<Enrollment> _enrollments;

        public CannotAddGradeToUnenrolledStudentRule(StudentId studentId, CourseId courseId, List<Enrollment> enrollments)
        {
            _studentId = studentId;
            _courseId = courseId;
            _enrollments = enrollments;
        }

        public bool IsViolated() => _enrollments.SingleOrDefault(e => e.CourseId == _courseId && e.StudentId == _studentId) == null;

        public string Message => $"Cannot add grade ,student is not enrolled to this course.";
    }
}
