using System.Net.NetworkInformation;
using System.Reflection;
using DomainEvent;
using DomainEvent.EventsHandlers;
using IDomainEvent = DomainEvent.EventsHandlers.IDomainEvent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDomainEvent, DomainEvent.EventsHandlers.DomainEvent>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateAuthorCommand).Assembly));



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

app.Run();