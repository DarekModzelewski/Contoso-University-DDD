using ContosoUniversity.SharedKernel.Domain;
using System;

namespace ContosoUniversity.Modules.Courses.Domain.Departments.Events
{
    public class DepartmentCreatedDomainEvent : DomainEventBase
    {
        public Guid DepartmentId { get; }
        public string Name { get; }
        public decimal Budget { get; }
        public string Currency { get; }
        public DateTime Moment { get; }
        public DateTime StartDate { get; }
        public DepartmentCreatedDomainEvent(
            Guid departmentId,
            string name,
            decimal budget,
            string currency,
            DateTime moment,
            DateTime startDate)
        {
            DepartmentId = departmentId;
            Name = name;
            Budget = budget;
            Currency = currency;
            Moment = moment;
            StartDate = startDate;
        }
    }
}
