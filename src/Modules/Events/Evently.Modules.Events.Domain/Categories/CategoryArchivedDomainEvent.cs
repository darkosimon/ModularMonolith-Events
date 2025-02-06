using Evently.Modules.Events.Domain.Events.Abstractions;

namespace Evently.Modules.Events.Domain.Categories;
public sealed class CategoryArchivedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
