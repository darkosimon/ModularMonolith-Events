using Evently.Modules.Events.Domain.Events.Abstractions;

namespace Evently.Modules.Events.Domain.TicketTypes;
public sealed class TicketTypeCreatedDomainEvent(Guid ticketTypeId) : DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}
