using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructorDetails;
using System.Collections.Generic;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructors
{
    public class GetInstructorsQuery : IQuery<IEnumerable<InstructorDto>>
    {
        public GetInstructorsQuery()
        {
        }       

    }
}