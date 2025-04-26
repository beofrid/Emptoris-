using Emptoris.Model;
using Emptoris.Data.DBInterfaces;

namespace Emptoris.Data.Repositories
{
    public class ListRepository : DBAccess, ITableHandler<ListItem>
    {
        public async Task<List<ListItem>> GetAllFromTableAsync()
        {
             return await _connection.Table<ListItem>().ToListAsync();
        }

        public async Task<ListItem> GetByIdAsync(int id)
        {
            return await _connection.Table<ListItem>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<ListItem> GetByNameAsync(string name)
        {
            //ListItem table doesn't have a name column.
            throw new NotImplementedException();
        }

        public async Task AddAsync(ListItem obj)
        {
            var itemExists = await _connection.Table<Item>().Where(x => x.Id == obj.FK_ItemID).FirstOrDefaultAsync();
            var listExists = await _connection.Table<ShoppingList>().Where(x => x.Id == obj.FK_ListId).FirstOrDefaultAsync();

            if (itemExists != null && listExists != null)
            {
                await _connection.InsertAsync(obj);
            }
            else
            {
                throw new Exception("DB ERROR: Item or list not found.");
            }
        }

        public async Task DeleteAsync(ListItem obj)
        {
            await _connection.DeleteAsync(obj);
        }

        public async Task UpdateAsync(ListItem obj)
        {
            await _connection.UpdateAsync(obj);
            
        }
    }
}
