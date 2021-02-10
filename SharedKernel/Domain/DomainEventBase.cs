using System;

namespace ContosoUniversity.SharedKernel.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTime TimeStamp { get; }

        public DomainEventBase()
        {
            TimeStamp = DateTime.UtcNow;
        }
    }
}