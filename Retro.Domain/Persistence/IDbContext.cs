using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Retro.Domain.Persistence
{
    public interface IDbContext
    {
        DocumentClient Client { get; }
        Database Database { get; }
        DocumentCollection DocumentCollection { get; }
    }
}