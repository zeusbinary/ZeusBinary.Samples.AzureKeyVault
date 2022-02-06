using Microsoft.Extensions.Configuration;
using ZeusBinary.Samples.AzureKeyVault.Models;

namespace ZeusBinary.Samples.AzureKeyVault.Utils
{
    public static class ConfigurationUtil
    {
        public static ConfigurationModel GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            return new ConfigurationModel()
            {
                KeyVaultUrl = configuration.GetSection("Configuration:KeyVaultUrl").Value,
                TenantId = configuration.GetSection("Configuration:TenantId").Value,
                ClientId = configuration.GetSection("Configuration:ClientId").Value,
                ClientSecret = configuration.GetSection("Configuration:ClientSecret").Value,
                DatabaseConnectionStringSecretName = configuration.GetSection("Configuration:DatabaseConnectionStringSecretName").Value
            };
        }
    }
}
