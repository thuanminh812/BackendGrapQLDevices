
using APIGGGDevices.GraphQL.PlaylistTimeQL;
using APIGGGDevices.GraphQL.ContentGroupQL;


using APIGGGDevices.Models;

using Microsoft.EntityFrameworkCore;
using APIGGGDevices.GraphQL.TotalScenarioQL;
using APIGGGDevices.GraphQL.AudioGroupQL;
using APIGGGDevices.GraphQL.DevicesQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GGGDevicesContext>(options
    =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnect"));
});
builder.Services.AddGraphQL();
builder.Services.AddGraphQLServer()
    .AddQueryType(x => x.Name("Query"))
    .AddTypeExtension<PlaylistTimeQuery>()
    .AddTypeExtension<ContentGroupQuery>()
    .AddTypeExtension<TotalScenarioQuery>()
    .AddTypeExtension<AudioGroupQuery>()
    .AddTypeExtension<DevicesQuery>()
    .AddMutationType(x => x.Name("Mutation"))
    .AddTypeExtension<PlaylistTimeMutation>()
    .AddTypeExtension<ContentGroupMutation>()
    .AddTypeExtension<TotalScenarioMutation>()
    .AddTypeExtension<AudioGroupMutation>()
    .AddTypeExtension<DevicesMutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();
app.Run();
