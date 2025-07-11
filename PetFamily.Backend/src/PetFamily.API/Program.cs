using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PetFamily.API.Extensions;
using PetFamily.API.Middlewares;
using PetFamily.API.Validation;
using PetFamily.Application;
using PetFamily.Domain.Shared;
using PetFamily.Infrastructure;
using Serilog;
using Serilog.Events;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq(builder.Configuration.GetConnectionString("CS_SEQ_SERVER"))//"http://172.18.0.4:5341"
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
    .CreateLogger();

Log.Information("Starting web application");
Log.Error(Error.Failure("999","My error message").Serialize());

builder.Services.AddSerilog(); 
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
app.UseExceptionMiddleware();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //await app.ApplyMigration();
}

app.MapControllers();

app.Run();

// Important to call at exit so that batched events are flushed.
Log.Information("Application shutdown!");
await Log.CloseAndFlushAsync();