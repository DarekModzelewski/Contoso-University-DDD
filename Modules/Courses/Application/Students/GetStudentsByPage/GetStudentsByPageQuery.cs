using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;

namespace ContosoUniversity.Modules.Courses.Application.Students.GetStudentsByPage
{
    public class GetStudentsByPageQuery : QueryBase<PagedStudentsDto>
    {
        public GetStudentsByPageQuery(
            int? pageNumber,
            int? pageSize,
            string sortOrder,
            string currentFiler,
            string searchString)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SortOrder = sortOrder;
            CurrentFilter = currentFiler;
            SearchString = searchString;
        }       
        public int? PageNumber { get; }
        public int? PageSize { get; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }

    }
}