using Evently.Api.Extensions;
using Evently.Modules.Events.Infrastructure;
using Evently.Common.Application;
using Evently.Common.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddApplication([Evently.Modules.Events.Application.AssemblyReference.Assembly]);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);

builder.Configuration.AddModuleConfiguration(["events"]);

builder.Services.AddEventModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
}

//// app.UseHttpsRedirection();

EventsModule.MapEndpoints(app);


app.Run();

