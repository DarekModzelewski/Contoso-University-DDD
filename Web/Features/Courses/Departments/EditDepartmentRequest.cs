using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Features.Courses.Departments
{
    public class EditDepartmentRequest
    {
        public Guid Id { get; set; }
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
