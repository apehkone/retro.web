namespace Retro.Domain.Persistence
{
    public class DbConfig : IDbConfig
    {
        private const string ENDPOINT_URL = @"https://retro.documents.azure.com:443/";
        private const string AUTHORIZATION_KEY = "9XJDrY6gYQXnSX+WWtNIr66fvEwRbvU98opG5owV5+4MRQoThVf7LLyq7cgABSeYnSy48+ek+oNcBUqDjr3lDw==";
        private const string DATA_BASE_ID = "RetroDb";
        private const string DOCUMENT_COLLECTION_ID = "RetroDb.Collection";

        public string EndpointUrl { get { return ENDPOINT_URL; } }
        public string AuthorizationKey { get { return AUTHORIZATION_KEY; } }
        public string DataBaseId { get { return DATA_BASE_ID; } }
        public string DocumentCollectionId { get { return DOCUMENT_COLLECTION_ID; } }
    }
}