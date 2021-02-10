using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Students.GetStudentDetails
{
    public class GetStudentDetailsQuery : QueryBase<StudentDto>
    {
        public Guid StudentId { get; set; }
        public GetStudentDetailsQuery(Guid studentId) => StudentId = studentId;       
    }
}
