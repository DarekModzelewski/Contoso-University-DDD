using System;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Students
{
    public class StudentId : TypedIdValueBase
    {       
        public StudentId(Guid value) : base(value)
        {
        }

    }
}