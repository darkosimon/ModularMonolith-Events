using Evently.Modules.Events.Domain.Events.Abstractions;

namespace Evently.Modules.Events.Domain.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
