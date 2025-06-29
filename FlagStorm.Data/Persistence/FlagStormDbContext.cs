using System.Linq.Expressions;
using FlagStorm.Data.Data;
using FlagStorm.Data.Feature;
using FlagStorm.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FlagStorm.Data.Persistence;


public class FlagStormDbContextFactory : IDesignTimeDbContextFactory<FlagStormDbContext>
{
   public FlagStormDbContext CreateDbContext(string[] args)
   {
      var optionsBuilder = new DbContextOptionsBuilder<FlagStormDbContext>();

      var configuration = DatabaseConfiguration.Localhost();
      var dbHost = configuration.Host;
      var dbPort = configuration.Port.ToString() ?? "5432";
      var dbName = configuration.Database;
      var dbUser = configuration.UserName;
      var dbPass = configuration.Password;

      var connectionString =
         $"Server={dbHost}; Port={dbPort}; Database={dbName}; Username={dbUser}; Password={dbPass};";
      optionsBuilder.UseNpgsql(connectionString);

      return new FlagStormDbContext(optionsBuilder.Options, DatabaseConfiguration.Localhost());
   }
}
public class FlagStormDbContext : DbContext
{
   public DbSet<FlagStormFeatureEntity> Features { get; set; }
   public DbSet<FlagStormTargetRuleEntity> TargetRules { get; set; }
   public DbSet<FlagStormFeatureRuntimeConfigEntity> RuntimeConfigs { get; set; }
   public DbSet<AppVersionRangeEntity> VersionRanges { get; set; }
   public DbSet<BrowserEntity> Browsers { get; set; }
   public DbSet<RegionEntity> Regions { get; set; }
   public DbSet<LocaleEntity> Locales { get; set; }
   public DbSet<DeviceTypeEntity> DeviceTypes { get; set; }
   public DbSet<OperatingSystemEntity> OperatingSystems { get; set; }
   public DbSet<EnvironmentNameEntity> Environments { get; set; }
   public DbSet<AccountIdEntity> AccountIds { get; set; }
   private DatabaseConfiguration? Configuration { get; set; }
   
  
   public FlagStormDbContext(DbContextOptions<FlagStormDbContext> options, DatabaseConfiguration configuration) : base(options)
   {
      Configuration = configuration;
   }
   
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      if (optionsBuilder.IsConfigured) return;
      if (Configuration == null) Configuration = DatabaseConfiguration.Localhost();
      var dbHost = Configuration.Host;
      var dbPort = Configuration.Port.ToString() ?? "5432";
      var dbName = Configuration.Database;
      var dbUser = Configuration.UserName;
      var dbPass = Configuration.Password;

      var connectionString =
         $"Server={dbHost}; Port={dbPort}; Database={dbName}; Username={dbUser}; Password={dbPass};";

      optionsBuilder.UseNpgsql(connectionString);
      optionsBuilder.UseLazyLoadingProxies();
   }

   


   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<FlagStormFeatureEntity>()
        .HasOne(f => f.RuntimeConfig)
        .WithOne()
        .HasForeignKey<FlagStormFeatureRuntimeConfigEntity>("FlagStormFeatureId") // shadow FK
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<FlagStormFeatureRuntimeConfigEntity>()
        .HasMany(f => f.TargetRules)
        .WithOne()
        .HasForeignKey("RuntimeConfigId") // shadow FK
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<FlagStormTargetRuleDto>()
        .HasOne(f => f.AppVersionRange)
        .WithOne()
        .HasForeignKey<AppVersionRangeEntity>("FlagStormTargetRuleId") // shadow FK
        .IsRequired(false)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<FlagStormTargetRuleDto>()
       .HasMany(f => f.Browsers);
    modelBuilder.Entity<FlagStormTargetRuleDto>()
       .HasMany(f => f.Regions);
    
    modelBuilder.Entity<FlagStormTargetRuleDto>()
       .HasMany(f => f.Locales);
    modelBuilder.Entity<FlagStormTargetRuleDto>()
       .HasMany(f => f.DeviceTypes);
    modelBuilder.Entity<FlagStormTargetRuleDto>()
       .HasMany(f => f.OperatingSystems);
    modelBuilder.Entity<FlagStormTargetRuleDto>()
       .HasMany(f => f.Environments);
    modelBuilder.Entity<FlagStormTargetRuleDto>()
       .HasMany(f => f.AccountIds);
}
}