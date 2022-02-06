using ZeusBinary.Samples.AzureKeyVault.Helpers;
using ZeusBinary.Samples.AzureKeyVault.Utils;


var configuration = ConfigurationUtil.GetConfiguration();
var kvHelper = new KeyVaultHelper(configuration);

Console.WriteLine(kvHelper.DbConnectionString);