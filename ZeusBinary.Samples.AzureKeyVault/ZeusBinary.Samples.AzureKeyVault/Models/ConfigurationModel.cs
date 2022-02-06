namespace ZeusBinary.Samples.AzureKeyVault.Models
{
    public class ConfigurationModel
    {
        #region Properties

        public string? KeyVaultUrl { get; set; }
        public string? TenantId { get; set; }
        public string? ClientId { get;set; }
        public string? ClientSecret { get;set; }

        public string? DatabaseConnectionStringSecretName { get; set; }

        #endregion

        #region .ctor

        public ConfigurationModel()
        {
        }

        #endregion
    }
}
