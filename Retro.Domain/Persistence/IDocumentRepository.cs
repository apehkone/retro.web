using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Retro.Domain.Entities;

namespace Retro.Domain.Persistence
{
    public interface IDocumentRepository<TDocument> where TDocument : DocumentEntityBase
    {
        Task<ResourceResponse<Document>> Save(TDocument item);
        IEnumerable<TDocument> Get(Func<TDocument, bool> filter = null);
        Task<ResourceResponse<Document>> Update(TDocument item);
        Task<ResourceResponse<Document>> Delete(TDocument item);
        Task<StoredProcedureResponse<dynamic>> ExecuteStoredProc(string procedure, dynamic[] parameters);
    }
}