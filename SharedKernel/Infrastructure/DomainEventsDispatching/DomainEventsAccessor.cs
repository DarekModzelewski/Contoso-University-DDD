using System.Collections.Generic;
using System.Linq;
using ContosoUniversity.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.SharedKernel.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly DbContext _contosoContext;

        public DomainEventsAccessor(DbContext contosoContext)
        {
            _contosoContext = contosoContext;
        }

        public List<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = _contosoContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = _contosoContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}