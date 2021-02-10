using ContosoUniversity.SharedKernel.Domain;
using System;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors
{
    public class InstructorId : TypedIdValueBase
    {      
        public InstructorId(Guid value) : base(value)
        {
        }
    }
}
