using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MediatR;
using Evently.Modules.Events.Application.Events.GetEvent;
using Evently.Common.Presentation.Endpoints;


namespace Evently.Modules.Events.Presentation.Events;
internal sealed class GetEvent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, ISender sender) =>
        {
            EventResponse @event = await sender.Send(new GetEventQuery(id));

            return @event is null ? Results.NotFound(@event) : Results.Ok(@event);
        })
            .WithTags(Tags.Events);

    }
}
