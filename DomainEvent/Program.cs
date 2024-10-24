using System.Net.NetworkInformation;
using System.Reflection;
using DomainEvent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDispatchDomainEvents, DispatchDomainEvents>();
//builder.Services.AddTransient<AuthorAddedHandler>();
//builder.Services.AddTransient<AuthorAddedHandler.AuthorUpdatedHandler>();

// Регистрация сервиса для отправки доменных событий
//builder.Services.AddTransient<DispatchDomainEvents>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AuthorAddedHandler).Assembly));



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