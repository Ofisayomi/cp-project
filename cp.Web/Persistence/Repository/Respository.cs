using cp.Web.Domain;
using cp.Web.Persistence.DbClient;
using Microsoft.Azure.Cosmos;

namespace cp.Web.Persistence.Repository;

public class Respository<T> : IRepository<T> where T : BaseEntity
{
    private readonly CosmosClientFactory _clientFactory;
    private Task<Database> _database;
    private Container _container;
    public Respository(CosmosClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _database = _clientFactory.CreateAsync();
    }

    public async Task<(bool, T)> CreateItem(T item)
    {
        string containerName = typeof(T).Name;
        _container = await (await _database).CreateContainerIfNotExistsAsync(containerName, item.PartitionKey);
        ItemResponse<T> response = await _container.CreateItemAsync<T>(item);
        return (response.StatusCode == System.Net.HttpStatusCode.Created, response.Resource);
    }

    public async Task<List<T>> GetItems(string sqlQuery)
    {
        QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
        _container = (await _database).GetContainer(typeof(T).Name);
        FeedIterator<T> iterator = _container.GetItemQueryIterator<T>(queryDefinition);
        List<T> items = new List<T>();
        while (iterator.HasMoreResults)
        {
            FeedResponse<T> resultSets = await iterator.ReadNextAsync();
            foreach (T item in resultSets)
            {
                items.Add(item);
            }
        }

        return items;
    }

    public async Task<(bool, T)> UpdateItem(string Id, T item)
    {
        _container = (await _database).GetContainer(typeof(T).Name);

        var resource = await _container.ReplaceItemAsync<T>(item, Id);
        return (true, resource);
    }

    public async Task<T> GetItem(string Id)
    {
        return (await GetItems($"SELECT * FROM c WHERE c.id='{Id}'")).FirstOrDefault();
    }

}
