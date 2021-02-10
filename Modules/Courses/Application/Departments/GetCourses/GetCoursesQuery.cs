using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Application.Departments.GetCourseDetails;
using System.Collections.Generic;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetCourses
{
    public class GetCoursesQuery : QueryBase<IEnumerable<CourseDto>>
    {
        public GetCoursesQuery()
        {
        }       

    }
}