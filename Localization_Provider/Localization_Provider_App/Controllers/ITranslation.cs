using Localization_Provider_App.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Localization_Provider_App.Controllers
{
    public interface ITranslation
    {
        Task<TranslationModel> GetTranslatedValue(string type);
    }

    public class AzureStorageTranslation : ITranslation
    {
        public async Task<TranslationModel> GetTranslatedValue(string type)
        {
            string connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
            TranslationModel TransalationModels = await GetTranslatedValue(connectionString, type);
            return TransalationModels;
        }

        private static async Task<TranslationModel> GetTranslatedValue(string ConnectionString, string type)
        {
            CloudTable table;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            string _CloudTableName = "localization";
            table = tableClient.GetTableReference(_CloudTableName);
            await table.CreateIfNotExistsAsync();

            TableQuery<TranslationModel> query = new TableQuery<TranslationModel>();
            string filter = TableQuery.GenerateFilterCondition("Type", QueryComparisons.Equal, type);
            query = query.Where(filter);
            TranslationModel TransalationModels = table.ExecuteQuery(query).FirstOrDefault();
            return TransalationModels;
        }
    }
}