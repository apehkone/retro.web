namespace Retro.Domain.Persistence
{
    public class DbConfig : IDbConfig
    {
        private const string ENDPOINT_URL = @"https://retro.documents.azure.com:443/";
        private const string AUTHORIZATION_KEY = "CSVpEnbbcxS2EUI1moMRvYV2CauFpS0j7b72ybhD8TZCF4cDbFIJAzxpzws26VVopb6XFpTFy2GDVgFYjJaW4A==";
        private const string DATA_BASE_ID = "RetroDb";
        private const string DOCUMENT_COLLECTION_ID = "RetroDb.Collection";

        public string EndpointUrl { get { return ENDPOINT_URL; } }
        public string AuthorizationKey { get { return AUTHORIZATION_KEY; } }
        public string DataBaseId { get { return DATA_BASE_ID; } }
        public string DocumentCollectionId { get { return DOCUMENT_COLLECTION_ID; } }
    }

    public class IdentityDbConfig : IDbConfig
    {
        private const string ENDPOINT_URL = @"https://retro.documents.azure.com:443/";
        private const string AUTHORIZATION_KEY = "CSVpEnbbcxS2EUI1moMRvYV2CauFpS0j7b72ybhD8TZCF4cDbFIJAzxpzws26VVopb6XFpTFy2GDVgFYjJaW4A===";
        private const string DATA_BASE_ID = "RetroDb";
        private const string DOCUMENT_COLLECTION_ID = "Identity";

        public string EndpointUrl { get { return ENDPOINT_URL; } }
        public string AuthorizationKey { get { return AUTHORIZATION_KEY; } }
        public string DataBaseId { get { return DATA_BASE_ID; } }
        public string DocumentCollectionId { get { return DOCUMENT_COLLECTION_ID; } }
    }
}