using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.AssignInstructorToOffice
{
    public class AssignInstructorToOfficeCommand : CommandBase<Unit>
    {
        public Guid InstructorId { get; }      
        public string Address { get; }
        public string PostalCode { get; }
        public string City { get; }

        public AssignInstructorToOfficeCommand(Guid instructorId,string address,string postalCode,string city)
        {
            InstructorId = instructorId;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
   
}
