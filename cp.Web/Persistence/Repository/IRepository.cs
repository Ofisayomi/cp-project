namespace cp.Web.Persistence.Repository;

public interface IRepository<T> where T : class
{
    Task<(bool, T)> CreateItem(T item);
    Task<(bool, T)> UpdateItem(T item);
    Task<List<T>> GetItems(string sqlQuery);
}
