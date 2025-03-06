using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Common.Application.Messaging;
using Evently.Modules.Events.Domain.Events;

namespace Evently.Modules.Events.Application.Events.RescheduleEvent;
internal sealed class EventRescheduledDomainEventHandler : IDomainEventHandler<EventRescheduledDomainEvent>
{
    public Task Handle(EventRescheduledDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
