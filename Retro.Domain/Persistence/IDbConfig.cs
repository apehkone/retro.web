namespace Retro.Domain.Persistence
{
    public interface IDbConfig
    {
        string EndpointUrl { get; }
        string AuthorizationKey { get; }
        string DataBaseId { get; }
        string DocumentCollectionId { get; }
    }
}