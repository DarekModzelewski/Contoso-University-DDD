using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Web.Features.Courses.Students
{
    public class EditStudentRequest
    {
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
    }
}
