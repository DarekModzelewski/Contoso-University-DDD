using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructorDetails
{
    public class InstructorDto
    {
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public class Course
        {
            public string Title { get; set; }
        }

    }
}
