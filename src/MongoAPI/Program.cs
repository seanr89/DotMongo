using Microsoft.Extensions.Options;
using MongoAPI.Models;
using MongoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

//Configure AppSettings and Add to DI
builder.Services.Configure<AppDbSettings>(
                configuration.GetSection(nameof(AppDbSettings)));
builder.Services.AddSingleton<AppDbSettings>(provider =>
                provider.GetRequiredService<IOptions<AppDbSettings>>().Value);

//Initialize the event services once!
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<EventTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapHealthChecks("/healthcheck");

app.MapControllers();

app.Run();
