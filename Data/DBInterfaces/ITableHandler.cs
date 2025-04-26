
namespace Emptoris.Data.DBInterfaces
{

    public interface ITableHandler<T> where T : class
    {
        Task<List<T>> GetAllFromTableAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> GetByNameAsync(string name);


        Task AddAsync(T obj);


        Task UpdateAsync(T obj);


        Task DeleteAsync(T obj);
    }
}