using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructorDetails
{
    public class GetInstructorDetailsQuery : QueryBase<InstructorDto>
    {
        public Guid InstructorId { get; set; }
        public GetInstructorDetailsQuery(Guid instructorId) => InstructorId = instructorId;       
    }
}
