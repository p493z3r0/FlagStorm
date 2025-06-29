namespace FlagStorm.Data.Data;


public class FlagStoreAuthenticationOptions
{
    public required string Host { get; set; }
    public required string Secret { get; set; }
}

public class DatabaseConfiguration
{
    public required string Host { get; set; }
    public required int Port { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Schema { get; set; } = "FlagStorm";
    public required string Database { get; set; } = "FlagStorm";

    public static DatabaseConfiguration Localhost()
    {
        return new DatabaseConfiguration()
        {
            Host = "localhost",
            Port = 5432,
            UserName = "postgres",
            Password = "1234",
            Schema = "FlagStorm",
            Database = "FlagStorm"
        };
    }
}
public class FlagStormOptions
{
    public int CacheDurationSeconds { get; set; } = 60;
    public bool FlagStormPersistenceEnabled { get; set; } = true;
    public bool UseCentralPersistenceServer { get; set; } = false;
    
    public DatabaseConfiguration? Database { get; set; }
    public FlagStoreAuthenticationOptions? CentralPersistenceServerConfiguration { get; set; }
    public int DefaultFeatureRuntimeBeforeConsideredError { get; set; } = 20;
    // Other config options here
}