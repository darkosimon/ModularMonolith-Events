namespace Evently.Modules.Events.Domain.Events.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccuredOnUtc { get; }
}
