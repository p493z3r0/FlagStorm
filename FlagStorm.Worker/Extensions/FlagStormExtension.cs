using FlagStorm.Data.Data;
using FlagStorm.Data.Data.Interceptors;
using FlagStorm.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace FlagStorm.Worker.Extensions;


public static class FlagStormExtension
{
    public static IServiceCollection AddFlagStorm(this IServiceCollection services,  Action<FlagStormOptions>? configure = null)
    {
        var options = new FlagStormOptions();
        configure?.Invoke(options);
        if(options.UseCentralPersistenceServer && options.FlagStormPersistenceEnabled) throw new Exception("Usage of both inbuild persistence and central persistence is not supported");
        if (options.UseCentralPersistenceServer && options.CentralPersistenceServerConfiguration == null)
            throw new Exception("Usage of central server requires central persistence configuration object");

        if (options.FlagStormPersistenceEnabled && options.Database == null)
            throw new Exception("Database configuration required when using local persistence");
        
        if (options.FlagStormPersistenceEnabled)
        {
            var dbConfig = options.Database!;
            var connectionString = new Npgsql.NpgsqlConnectionStringBuilder
            {
                Host = dbConfig.Host,
                Port = dbConfig.Port,
                Username = dbConfig.UserName,
                Password = dbConfig.Password,
                Database = dbConfig.Database,
                SslMode = SslMode.Allow
            }.ToString();

            services.AddSingleton(options.Database!);
            services.AddDbContext<FlagStormDbContext>(cfg =>
            {
                cfg.AddInterceptors(new MetadataInterceptor());
                cfg.UseNpgsql(connectionString, npgsqlOptions => { });
            });
        }
        services.AddSingleton<Worker>();
        return services;
    }

    public static IServiceCollection AddFlagStormPersistence(this IServiceCollection services,
        Action<FlagStormOptions>? configure = null)
    {
        services.AddDbContext<FlagStormDbContext>();
        return services;
    }
}