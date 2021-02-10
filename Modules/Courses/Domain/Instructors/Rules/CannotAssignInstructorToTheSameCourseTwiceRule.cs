using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Rules
{
    public class CannotAssignInstructorToTheSameCourseTwiceRule : IDomainRule
    {     
        private readonly InstructorId _instructorId;
        private readonly CourseId _courseId;
        private readonly List<Assignment> _assignments;

        public CannotAssignInstructorToTheSameCourseTwiceRule(InstructorId instructorId,CourseId courseId,List<Assignment> assignments)
        {         
            _instructorId = instructorId;
            _courseId = courseId;
            _assignments = assignments;
        }

        public bool IsViolated() => _assignments.SingleOrDefault(a => a.InstructorId == _instructorId && a.CourseId == _courseId) != null;

        public string Message => $"Instructor cannot be assigned twice to the same course.";
    }
}
