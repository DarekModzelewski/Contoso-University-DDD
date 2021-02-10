using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Events
{
    public class InstructorAssignedToOfficeDomainEvent : DomainEventBase
    {
        public InstructorId InstructorId { get; }
        public string Address { get; }
        public string PostalCode { get; }
        public string City { get; }
        public InstructorAssignedToOfficeDomainEvent(
            InstructorId instructorId,
            string address,
            string postalCode,
            string city)
        {
            InstructorId = instructorId;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
    }
}
