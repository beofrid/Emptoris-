using Emptoris.Model;
using Emptoris.Data.DBInterfaces;
using System.Diagnostics;
using SQLite;

namespace Emptoris.Data.Repositories
{
    public class ItemRepository : DBAccess, ITableHandler<Item>
    {
        public async Task<Item> GetByIdAsync(int id)
        {
            return await _connection.Table<Item>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Item> GetByNameAsync(string name)
        {
            return await _connection.Table<Item>().Where(x => x.ItemName == name).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetAllFromTableAsync()
        {
            try
            {
                Debug.WriteLine("GetAllFromTableAsync", "Item REPOSITORY");
                var items = await _connection.Table<Item>().ToListAsync();  // Fetch all items from the table
                Debug.WriteLine(items.Count.ToString(), "Item REPOSITORY");  // Log the count of items

                return items;  // Return the fetched items
            }
            catch (SQLiteException sqlEx)
            {
                Debug.WriteLine($"SQLiteException: {sqlEx.Message}", "ERROR");
                return new List<Item>();  // Return an empty list if there's an error
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}", "ERROR");
                return new List<Item>();  // Return an empty list for any other general errors
            }
           
        }

        public async Task AddAsync(Item item)
        {
            await _connection.InsertAsync(item);
            
        }

        public async Task DeleteAsync(Item item)
        {
            await _connection.DeleteAsync(item);
            
        }
        public async Task UpdateAsync(Item item)
        {
            await _connection.UpdateAsync(item);

        }
    }
}


