using Evently.Modules.Events.Application.Categories.GetCategories;
using Evently.Modules.Events.Application.Categories.GetCategory;
using Evently.Common.Domain;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Evently.Common.Application.Caching;

namespace Evently.Modules.Events.Presentation.Categories;

internal static class GetCategories
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async ( ISender sender, ICacheService cacheService, CancellationToken cancellationToken) =>
        {
           IReadOnlyCollection<CategoryResponse> categoryReponse = await cacheService.GetAsync<IReadOnlyCollection<CategoryResponse>>("categories", cancellationToken);

            if(categoryReponse is not null)
            {
                return Results.Ok(categoryReponse);
            }

            Result<IReadOnlyCollection<CategoryResponse>> result = await sender.Send(new GetCategoriesQuery(), cancellationToken);

            if (result.IsSuccess)
            {
                await cacheService.SetAsync("categories", result.Value, cancellationToken: cancellationToken);
            }

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
