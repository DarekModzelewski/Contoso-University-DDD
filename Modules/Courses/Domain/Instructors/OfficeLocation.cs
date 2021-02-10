using ContosoUniversity.SharedKernel.Domain;
namespace ContosoUniversity.Modules.Courses.Domain.Instructors
{
    public class OfficeLocation : ValueObject
    {
        public string Address { get; }

        public string PostalCode { get; }

        public string City { get; }
        
        internal OfficeLocation(string address, string postalCode, string city)
        {
            Address = address;
            PostalCode = postalCode;
            City = city;
        }
        internal OfficeLocation CreateNew(string address, string postalCode, string city)
        {
            return new OfficeLocation(address,postalCode,city);
        }

       
    }
}
