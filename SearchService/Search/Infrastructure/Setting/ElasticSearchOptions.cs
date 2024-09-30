namespace Search.Infrastructure.Setting
{
    public sealed class ElasticSearchOptions
    {
        public required string Host { get; init; }
        public required string Fingerprint { get; init; }
        public required string UserName { get; init; }
        public required string Password { get; init; }
    }
}