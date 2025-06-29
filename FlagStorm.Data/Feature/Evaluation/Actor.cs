
namespace FlagStorm.Data.Data;



public class Actor
{
    public required string Id { get; init; }
    public required string AccountId { get; init; }
    public required string Customer { get; set; }
    public required List<string> Claims  { get; init; } = new();
}