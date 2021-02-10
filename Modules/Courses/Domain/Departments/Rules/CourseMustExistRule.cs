using ContosoUniversity.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Domain.Departments.Rules
{
    public class CourseMustExistRule : IDomainRule
    {
        private readonly List<Course> _courses;

        private readonly CourseId _courseId;

        public CourseMustExistRule(List<Course> courses, CourseId courseId)
        {
            _courses = courses;
            _courseId = courseId;
        }

        public bool IsViolated() => _courses.SingleOrDefault(c => c.Id == _courseId) == null;

        public string Message => $"Course with id: {_courseId.Value} does not exist in this department.";
    }
}
