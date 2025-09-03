using ApartmentManagementSystem.Contracts.Services;
using Identity.Application;
using Identity.Controller;
using Identity.Infrastructure;
using Leasing.Application;
using Leasing.Controller;
using Billing.Infrastructure;
using Leasing.Infrastructure;
using Microsoft.OpenApi.Models;
using Property.Application;
using Property.Controller;
using Property.Infrastructure;
using Scalar.AspNetCore;
using Billing.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AccountsController).Assembly)
    .AddApplicationPart(typeof(LeasingsController).Assembly)
    .AddApplicationPart(typeof(OwnershipsController).Assembly)
    .AddApplicationPart(typeof(OwnersController).Assembly)
    .AddApplicationPart(typeof(RolesController).Assembly)
    .AddApplicationPart(typeof(BuildingsController).Assembly)
    .AddApplicationPart(typeof(UnitsController).Assembly);

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

//Identity
builder.Services.AddIdentityApplication();
builder.Services.AddIdentityInfrastructure(builder.Configuration);


//Leasing
builder.Services.AddLeasingApplication();
builder.Services.AddLeasingInfrastructure(builder.Configuration);

//Property
builder.Services.AddPropertyApplication();
builder.Services.AddPropertyInfrastructure(builder.Configuration);

//Billing
builder.Services.AddBillingApplication();
builder.Services.AddBillingInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Identity.Application.AssemblyReference).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Leasing.Application.AssemblyReference).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Property.Application.AssemblyReference).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Billing.Application.AssemblyReference).Assembly);
});

builder.Services.AddAutoMapper(_ => { }, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.MapScalarApiReference(options => options
        .WithTheme(ScalarTheme.Moon)
        .WithDarkMode()
    ); 
}


app.MapControllers();

app.Run();
