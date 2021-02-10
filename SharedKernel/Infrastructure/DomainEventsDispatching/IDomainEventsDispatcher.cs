using System.Threading.Tasks;

namespace ContosoUniversity.SharedKernel.Infrastructure.DomainEventsDispatching
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}