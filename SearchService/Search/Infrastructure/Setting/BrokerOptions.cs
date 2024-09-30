namespace Search.Infrastructure.Setting;

public sealed class BrokerOptions
{
    public const string SectionName = "BrokerOptions";

    public required string Host { get; init; }
    public required string UserName { get; init; }
    public required string Password { get; init; }
}