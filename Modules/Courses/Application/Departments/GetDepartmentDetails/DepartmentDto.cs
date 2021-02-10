using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetDepartmentDetails
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Administrator { get; set; }
        public string Name { get; set; }
        public string  Currency { get; set; }
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public class Course
        {
            public string Title { get; set; }
            public int Credits { get; set; }
        }
       
    }
}
