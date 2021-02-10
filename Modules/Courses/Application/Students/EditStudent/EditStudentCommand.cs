using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Students.EditStudent
{
    public class EditStudentCommand : CommandBase<Unit>
    {
        public Guid StudentId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime EnrollementDate { get; }

        public EditStudentCommand(Guid studentId,string firstName, string lastName, DateTime enrollmentDate)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            EnrollementDate = enrollmentDate;
        }
    }
}
