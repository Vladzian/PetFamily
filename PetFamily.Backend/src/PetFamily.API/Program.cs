using PetFamily.Application;
using PetFamily.Application.Repositories;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Domain.Volunteer;
using PetFamily.Infrastructure;
using PetFamily.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using PetFamily.API.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
      .AddInfrastructure()
      .AddApplication();

builder.Services.AddFluentValidationAutoValidation(configuration => 
{
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app.RunAsync();