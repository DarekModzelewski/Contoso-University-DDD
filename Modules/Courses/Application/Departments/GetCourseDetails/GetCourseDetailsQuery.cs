using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetCourseDetails
{
    public class GetCourseDetailsQuery : QueryBase<CourseDto>
    {
        public Guid CourseId { get; set; }
        public Guid DepartmentId { get; set; }
        public GetCourseDetailsQuery(Guid courseId,Guid departmentId) 
        {
            CourseId = courseId;
            DepartmentId = departmentId;
        }     
    }
}
