using Serilog;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);


//!Serilog Configuration
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"Serilog.json", false)
    .AddJsonFile($"Serilog.{env}.json", true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.WithProperty("NewProperty", "test")
    .CreateLogger();

builder.Host.UseSerilog();

var user = new { Name = "Serilog", Environment = env, Temp="test" };
Log.Warning("Hello {@user}", user);


builder.Services.AddControllers();
builder.Services.AddLogging(); //!Add logging
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


app.Run();
