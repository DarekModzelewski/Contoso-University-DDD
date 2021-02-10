using System;
using MediatR;

namespace ContosoUniversity.SharedKernel.Domain
{
    public interface IDomainEvent : INotification
    {
        DateTime TimeStamp { get; }
    }
}