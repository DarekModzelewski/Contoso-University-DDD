using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Students.DeleteStudent
{
    public class DeleteStudentCommand : CommandBase<Unit>
    {
        public Guid StudentId { get; }

        public DeleteStudentCommand(Guid studentId) => StudentId = studentId;

    }
   
}
