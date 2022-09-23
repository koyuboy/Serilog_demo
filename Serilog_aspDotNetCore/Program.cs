using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Host.UseSerilog((ctx, loggerConfiguration) => //configure serilog
//{
//    var loger = loggerConfiguration
//        .ReadFrom.Configuration(ctx.Configuration)
//        .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name)
//        .Enrich.WithProperty("Environment", ctx.HostingEnvironment);
//});

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    //.AddJsonFile("appsettings.json")
    .AddJsonFile($"Serilog.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
    .Build();

Log.Logger = new LoggerConfiguration()
    //.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .CreateLogger();


builder.Host.UseSerilog();


builder.Services.AddControllers();
builder.Services.AddLogging(); //Add logging
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

//app.UseSerilogRequestLogging();// This will make the HTTP requests log as rich logs instead of plain text.
//app.UseSerilogRequestLogging(options =>
//{
//    // Customize the message template
//    options.MessageTemplate = "Handled {RequestPath}";
//});

app.UseAuthorization();

app.MapControllers();


app.Run();
