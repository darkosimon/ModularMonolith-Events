using Evently.Modules.Events.Application.Categories.GetCategories;
using Evently.Modules.Events.Application.Categories.GetCategory;
using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Evently.Common.Application.Caching;
using Evently.Common.Presentation.Endpoints;

namespace Evently.Modules.Events.Presentation.Categories;

internal sealed class GetCategories : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async (ISender sender, ICacheService cacheService, CancellationToken cancellationToken) =>
        {
            IReadOnlyCollection<CategoryResponse> categoryReponse = await cacheService.GetAsync<IReadOnlyCollection<CategoryResponse>>("categories", cancellationToken);

            if (categoryReponse is not null)
            {
                return Results.Ok(categoryReponse);
            }

            Result<IReadOnlyCollection<CategoryResponse>> result = await sender.Send(new GetCategoriesQuery(), cancellationToken);

            if (result.IsSuccess)
            {
                await cacheService.SetAsync("categories", result.Value, cancellationToken: cancellationToken);
            }

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
