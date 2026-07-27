using Evently.Common.Presentation.Endpoints;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Ticketing.Presentation.Carts;
internal sealed class RemoveFromCart : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
    }

    internal sealed class Request
    {
        public Guid TicketTypeId { get; init; }
    }
}
