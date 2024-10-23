using System.Reflection;
using FluentMigrator.Runner;
using TFirewall.Source.Middleware;
using TFirewall.Source.Service.User.UserCrudService;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.SystemConfig.DatabaseAndMigrations;
using TFirewall.Source.UserAppConfig.AppState;
using TFirewall.Source.UserAppConfig.Entities;
using Unity;
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

IUnityContainer container = IocConfig.GetConfiguredContainer();
UserProfile userProfile = await container.Resolve<IUserCrudService>().GetActiveUserProfileAsync();
container.Resolve<IAppState>().SetActiveUserProfile(userProfile);

WebApplication app = builder.Build();

app.UseMiddleware<RequestInspectorMiddleware>()
    .UseMiddleware<LoggingMiddleware>()
    .UseMiddleware<RequestForwarderMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(Constants.AllowAllCorsPolicyName);

app.MigrateDatabase(app.Services.GetRequiredService<ILogger<Program>>()).Run();