using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlagStorm.Data.Persistence.Public;

public static class MigrationHelper
{
    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<FlagStormDbContext>();
        context.Database.Migrate();
    }
}