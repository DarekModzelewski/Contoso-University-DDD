using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Modules.Courses.Application.Students.GetStudentDetails
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }

        public class Enrollment
        {
            public string Title { get; set; }
            public string Grade { get; set; }
        }
       
    }
}
