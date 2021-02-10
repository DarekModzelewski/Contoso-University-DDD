using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetDepartmentDetails
{
    public class GetDepartmentDetailsQuery : QueryBase<DepartmentDto>
    {
        public Guid DepartmentId { get; set; }
        public GetDepartmentDetailsQuery(Guid departmentId) => DepartmentId = departmentId;       
    }
}
