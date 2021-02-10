using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Students.CreateStudent
{
    public class CreateStudentCommand : CommandBase<Unit>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime EnrollementDate { get; }

        public CreateStudentCommand(string firstName, string lastName, DateTime enrollmentDate)
        {
            FirstName = firstName;
            LastName = lastName;
            EnrollementDate = enrollmentDate;
        }
    }
   
}
