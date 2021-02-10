using System.Collections.Generic;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.SharedKernel.Infrastructure.DomainEventsDispatching
{
    public interface IDomainEventsAccessor
    {
        List<IDomainEvent> GetAllDomainEvents();
        void ClearAllDomainEvents();
    }
}