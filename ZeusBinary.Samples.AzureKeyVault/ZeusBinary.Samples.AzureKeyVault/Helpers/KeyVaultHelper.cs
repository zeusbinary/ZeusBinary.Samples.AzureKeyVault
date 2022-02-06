using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ZeusBinary.Samples.AzureKeyVault.Models;

namespace ZeusBinary.Samples.AzureKeyVault.Helpers
{
    public class KeyVaultHelper
    {
        #region Fields

        private readonly ConfigurationModel _configurationModel;

        #endregion

        #region Properties

        public string? DbConnectionString { get; set; }

        #endregion

        #region .ctor

        public KeyVaultHelper(ConfigurationModel configurationModel)
        {
            _configurationModel = configurationModel;

            Init();
        }

        #endregion

        #region Methods

        private void Init()
        {
            if (string.IsNullOrEmpty(_configurationModel.TenantId))
            {
                throw new Exception("TenantId is null or empty.");
            }

            if (string.IsNullOrEmpty(_configurationModel.ClientId))
            {
                throw new Exception("ClientId is null or empty.");
            }

            if (string.IsNullOrEmpty(_configurationModel.ClientSecret))
            {
                throw new Exception("ClientSecret is null or empty.");
            }

            if (string.IsNullOrEmpty(_configurationModel.KeyVaultUrl))
            {
                throw new Exception("KeyVaultUrl is null or empty.");
            }

            ClientSecretCredential credential = new ClientSecretCredential(_configurationModel.TenantId,
                _configurationModel.ClientId,
                _configurationModel.ClientSecret);

            var client = new SecretClient(vaultUri: new Uri(_configurationModel.KeyVaultUrl),
                credential: credential);

            var dbConnectionStrinResponse = client.GetSecret(_configurationModel.DatabaseConnectionStringSecretName);
            DbConnectionString = dbConnectionStrinResponse.Value.Value;
        }

        #endregion
    }
}
