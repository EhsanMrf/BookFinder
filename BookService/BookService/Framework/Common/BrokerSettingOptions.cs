namespace Framework.Common;

public sealed class BrokerSettingOptions
{
    public const string SectionName = "BrokerSettingOptions";

    public required string Host { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}