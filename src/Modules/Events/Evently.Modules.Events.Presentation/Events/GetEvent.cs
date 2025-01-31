using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MediatR;
using Evently.Modules.Events.Application.Events.GetEvent;


namespace Evently.Modules.Events.Presentation.Events;
internal  static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, ISender sender) =>
        {
             EventResponse @event = await sender.Send(new GetEventQuery(id));

            return @event is null ? Results.NotFound(@event) : Results.Ok(@event);
        })
            .WithTags(Tags.Events);

    }
}
