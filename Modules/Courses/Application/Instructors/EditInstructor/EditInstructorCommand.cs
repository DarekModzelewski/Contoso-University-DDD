using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.EditInstructor
{
    public class EditInstructorCommand : CommandBase<Unit>
    {
        public Guid InstructorId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime HireDate { get; }
        public string Address { get; }
        public string PostalCode { get; }
        public string City { get; }

        public EditInstructorCommand(
            Guid instructorId,
            string firstName,
            string lastName,
            DateTime hireDate,
            string address,
            string postalCode,
            string city)
        {
            InstructorId = instructorId;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
   
}
