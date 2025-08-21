using ApartmentManagementSystem.Contracts.Services;
using Identity.Application;
using Identity.Controller;
using Identity.Infrastructure;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AuthenticationController).Assembly);

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((doc, ctx, ct) =>
    {
        doc.Components ??= new();
        doc.Components.SecuritySchemes["BearerAuth"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization"
        };
        return Task.CompletedTask;
    });

    options.AddOperationTransformer((op, ctx, ct) =>
    {
        var hasAuth = ctx.Description.ActionDescriptor?.EndpointMetadata?
            .OfType<Microsoft.AspNetCore.Authorization.IAuthorizeData>()
            .Any() == true;

        if (hasAuth)
        {
            op.Security ??= new List<OpenApiSecurityRequirement>();
            op.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme, Id = "BearerAuth" }
                }] = Array.Empty<string>()
            });
        }
        return Task.CompletedTask;
    });
});


builder.Services.AddIdentityApplication();
builder.Services.AddIdentityInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Identity.Application.AssemblyReference).Assembly);
});


builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.MapScalarApiReference(options => options
        .WithTheme(ScalarTheme.Mars)
        .WithDarkMode()
    ); 
}


app.MapControllers();

app.Run();
