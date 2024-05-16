using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Cosmos;

namespace cp.Web.Persistence.DbClient;

public class CosmosClientFactory
{
    private Lazy<Task<Database>> _database;
    private readonly IConfiguration _config;
    public CosmosClientFactory(IConfiguration config){
        _config = config;
        var constring = _config["ConnectionStrings:Default"];
        var cosmosClient = new CosmosClient(constring, new CosmosClientOptions{
            ApplicationName = _config["AppName"]
        });

        _database = new (async()=>{
            return await cosmosClient.CreateDatabaseIfNotExistsAsync(_config["DbName"]);
        });

    }

    public Task<Database> CreateAsync()=> _database.Value;
}
