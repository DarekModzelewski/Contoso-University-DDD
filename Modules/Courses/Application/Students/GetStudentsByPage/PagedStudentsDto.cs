using ContosoUniversity.Modules.Courses.Application.Students.GetStudentDetails;
using System.Collections.Generic;

namespace ContosoUniversity.Modules.Courses.Application.Students.GetStudentsByPage
{
    public class PagedStudentsDto
    {
        public string CurrentSort { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int? ItemsPerPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
       
             
    }
}