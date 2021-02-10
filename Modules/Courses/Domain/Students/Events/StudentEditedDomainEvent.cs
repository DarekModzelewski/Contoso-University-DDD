using ContosoUniversity.SharedKernel.Domain;
using System;

namespace ContosoUniversity.Modules.Courses.Domain.Students.Events
{
    public class StudentEditedDomainEvent : DomainEventBase
    {
        public StudentId StudentId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime EnrollmentDate { get; }

        public StudentEditedDomainEvent(StudentId studentId, string firstName, string lastName,DateTime enrollmentDate)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            EnrollmentDate = enrollmentDate;
        }
    }
}
