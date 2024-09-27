using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Microsoft.OpenApi.Models; // Import for OpenApiInfo and related classes

var builder = WebApplication.CreateBuilder(args);

// Use specific URLs for the application
builder.WebHost.UseUrls("http://localhost:5200", "https://localhost:5001");

// Add services for CORS and Swagger
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Access Control API", Version = "v1" });
});

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAllOrigins");

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Access Control API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

// Define an in-memory data store
var restrictions = new List<Restriction>();
var services = new List<Service>();

// Define API endpoints

// Endpoint for adding a restriction
app.MapPost("/restrictions", (Restriction restriction) =>
{
    restriction.Id = restrictions.Count + 1; // Simple ID generation
    restrictions.Add(restriction);
    return Results.Created($"/restrictions/{restriction.Id}", restriction);
})
.WithName("AddRestriction")
.WithOpenApi();

// Endpoint for retrieving all restrictions
app.MapGet("/restrictions", () =>
{
    return Results.Ok(restrictions);
})
.WithName("GetRestrictions")
.WithOpenApi();

// Endpoint for adding a service
app.MapPost("/services", (Service service) =>
{
    service.Id = services.Count + 1; // Simple ID generation
    services.Add(service);
    return Results.Created($"/services/{service.Id}", service);
})
.WithName("AddService")
.WithOpenApi();

// Endpoint for retrieving all services
app.MapGet("/services", () =>
{
    return Results.Ok(services);
})
.WithName("GetServices")
.WithOpenApi();

// Run the application
app.Run();

// Define records for Restriction and Service
public record Restriction
{
    public int Id { get; set; }
    public required string CategoryS { get; init; }
    public required string CategoryP { get; init; }
}

public record Service
{
    public int Id { get; set; }
    public required string Name { get; init; }
}
