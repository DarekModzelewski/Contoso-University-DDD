using ContosoUniversity.SharedKernel.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Modules.Courses.Domain.Departments.Rules
{
    public class CourseCannotBeAddedTwiceRule : IDomainRule
    {
        private readonly List<Course> _courses;

        private readonly string _title;

        public CourseCannotBeAddedTwiceRule(List<Course> courses, string title)
        {
            _courses = courses;
            _title = title;
        }

        public bool IsViolated() => _courses.SingleOrDefault(c => c.Title.Contains(_title)) != null;

        public string Message => $"Course cannot be added twice,course with title: {_title} already exist. ";
    }
}
