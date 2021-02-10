using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.Modules.Courses.Application.Departments.GetDepartmentDetails;
using System.Collections.Generic;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetDepartments
{
    public class GetDepartmentsQuery : IQuery<IEnumerable<DepartmentDto>>
    {
        public GetDepartmentsQuery()
        {
        }       

    }
}