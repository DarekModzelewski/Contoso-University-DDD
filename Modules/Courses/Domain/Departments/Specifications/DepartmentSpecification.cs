using LinqBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Domain.Departments.Specifications
{
    public class DepartmentSpecification
    {
        public static ISpecification<Department> CourseId(CourseId courseId)
        {
            return Spec<Department>.New(d => d.Courses.Any(c => c.Id == courseId));
        }
    }
}
