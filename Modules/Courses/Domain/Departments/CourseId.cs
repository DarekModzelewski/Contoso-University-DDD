using System;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Departments
{
    public class CourseId : TypedIdValueBase
    {      
        public CourseId(Guid value) : base(value)
        {
        }
    }
}