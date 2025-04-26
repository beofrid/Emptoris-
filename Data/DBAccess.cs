using Emptoris.Model;
using SQLite;

namespace Emptoris.Data
{
    public class DBAccess
    {
        private const string DatabaseFilename = "SQLiteData.db3";
        protected readonly SQLiteAsyncConnection _connection;

        public DBAccess()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename));
            _connection.ExecuteAsync("PRAGMA foreign_keys = ON;").Wait();
            _connection.CreateTableAsync<Item>().Wait();
            _connection.CreateTableAsync<ShoppingList>().Wait();
            _connection.CreateTableAsync<ListItem>().Wait();

        }
        public SQLiteAsyncConnection GetConnection() => _connection;







    }
}
