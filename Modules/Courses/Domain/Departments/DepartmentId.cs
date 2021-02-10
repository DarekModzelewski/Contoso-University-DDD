using ContosoUniversity.SharedKernel.Domain;
using System;

namespace ContosoUniversity.Modules.Courses.Domain.Departments
{
    public class DepartmentId : TypedIdValueBase
    {      
        public DepartmentId(Guid value) : base(value)
        {
        }
    }
}
