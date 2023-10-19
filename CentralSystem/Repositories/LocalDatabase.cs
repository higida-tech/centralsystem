using SQLite;
using CentralSystem.Models;

namespace CentralSystem.Repositories
{
    public class LocalDatabase<T> where T : BaseModel, new()
    {
        SQLiteAsyncConnection Database;

        public LocalDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        async Task Init()
        {
            var result = await Database.CreateTableAsync<T>();
        }

        public async Task<List<T>> GetAll()
        {
            await Init();
            return await Database.Table<T>().OrderByDescending(c => c.Date).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            await Init();
            return await Database.Table<T>().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(T item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> Delete(T item)
        {
            return await Database.DeleteAsync(item);
        }
    }

    public static class Constants
    {
        public const string DatabaseFilename = "CheckoutSqlite.db3";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
