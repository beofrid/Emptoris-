using Emptoris.Model;
using Emptoris.Data.DBInterfaces;

namespace Emptoris.Data.Repositories
{
    class ShoppingListRepository : DBAccess, ITableHandler<ShoppingList>
    {
      
        public async Task<List<ShoppingList>> GetAllFromTableAsync()
        {
            return await _connection.Table<ShoppingList>().ToListAsync();
        }

        public async Task<ShoppingList> GetByIdAsync(int id)
        {
           return await _connection.Table<ShoppingList>().Where(x =>  x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ShoppingList> GetByNameAsync(string name)
        {
            return await _connection.Table<ShoppingList>().Where(x => x.ListName == name).FirstOrDefaultAsync();
        }
        public async Task AddAsync(ShoppingList obj)
        {
            await _connection.InsertAsync(obj);
        }

        public async Task DeleteAsync(ShoppingList obj)
        {
            await _connection.DeleteAsync(obj);
        }

        public async Task UpdateAsync(ShoppingList obj)
        {
            await _connection.UpdateAsync(obj);
            
        }
    }
}
