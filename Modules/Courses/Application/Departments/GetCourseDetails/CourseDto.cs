using System;
using System.Collections.Generic;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetCourseDetails
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string  Credits { get; set; }
       
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Assignment> Assignmets { get; set; }

        public class Enrollment
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Assignment
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }
}
