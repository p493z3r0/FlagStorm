namespace FlagStorm.Data.Data.Interfaces;

public interface ITarget
{
    public Task<bool> DoesMatch();
    public Task Invoked();
}