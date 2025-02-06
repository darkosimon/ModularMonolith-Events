using Evently.Modules.Events.Domain.Events.Abstractions;

namespace Evently.Modules.Events.Domain.Events;
public sealed class EventPublishedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
