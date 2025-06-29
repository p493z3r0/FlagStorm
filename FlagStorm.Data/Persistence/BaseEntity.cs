namespace FlagStorm.Data.Data;

public class BaseEntity
{
    public required string Id { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set;} = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set;} = DateTimeOffset.UtcNow;
}