using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Host.UseSerilog((ctx, loggerConfiguration) => //configure serilog
//{
//    var loger = loggerConfiguration
//        .ReadFrom.Configuration(ctx.Configuration)
//        .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name)
//        .Enrich.WithProperty("Environment", ctx.HostingEnvironment);
//});

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();


builder.Host.UseSerilog(logger);


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


app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();// This will make the HTTP requests log as rich logs instead of plain text.

app.Run();
