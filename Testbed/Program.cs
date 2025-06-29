
using System.Reflection;
using FlagStorm.Data.Data;
using FlagStorm.Data.Persistence.Public;
using FlagStorm.Worker.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFlagStorm(cfg =>
{
    cfg.CacheDurationSeconds = 15;
    cfg.FlagStormPersistenceEnabled = true;
    cfg.Database = DatabaseConfiguration.Localhost();
});

builder.Services.AddApiServices();

var app = builder.Build();

app.MapControllers();

MigrationHelper.MigrateDatabase(app.Services);

app.Run();