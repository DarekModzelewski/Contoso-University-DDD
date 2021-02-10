using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Events
{
    public class InstructorEditedDomainEvent : DomainEventBase
    {
        public InstructorId InstructorId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string PostalCode { get; }
        public string City { get; }
        public InstructorEditedDomainEvent(
            InstructorId instructorId,
            string firstName,
            string lastName,
            string address,
            string postalCode,
            string city)
        {
            InstructorId = instructorId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
}
