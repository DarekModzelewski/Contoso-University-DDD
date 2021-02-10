using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.CreateInstructor
{
    public class CreateInstructorCommand : CommandBase<Unit>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime HireDate { get; }
        public string Address { get; }

        public string PostalCode { get; }

        public string City { get; }

        public CreateInstructorCommand(
            string firstName,
            string lastName,
            DateTime hireDate,
            string address,
            string postalCode,
            string city)
        {
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
   
}
