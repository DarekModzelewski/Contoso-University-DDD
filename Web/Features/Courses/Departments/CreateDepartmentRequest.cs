using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Web.Features.Courses.Departments
{ 
    public class CreateDepartmentRequest
    {
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Budget { get; set; }
        [Required]
        public string Currency { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
    }
}