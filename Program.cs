using System.Reflection;
using FluentMigrator.Runner;
using TFirewall.Source.Middleware;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.SystemConfig.DatabaseAndMigrations;
using Constants = TFirewall.Source.Util.Constants;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

// logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
    .AddFluentMigratorCore()
    .ConfigureRunner(c => c.AddMySql8()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString(Constants.DevSqlConnectionKey))
        .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        Constants.AllowAllCorsPolicyName,
        policy => { policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod(); }
    );
});

IocConfig.RegisterComponents(builder.Configuration);

WebApplication app = builder.Build();

// app.UseMiddleware<RequestInspectorMiddleware>().UseMiddleware<LoggingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(Constants.AllowAllCorsPolicyName);

string[] summaries =
[
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
];

app.MapGet("/weatherforecast", () =>
    {
        WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MigrateDatabase(app.Services.GetRequiredService<ILogger<Program>>()).Run();


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}