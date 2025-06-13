using SQLite;
using _15830MAUI.Models;

namespace _15830MAUI.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public async Task<bool> RegisterUser(User user)
        {
            try
            {
                var existingUser = await _database.Table<User>()
                    .Where(u => u.Email == user.Email)
                    .FirstOrDefaultAsync();

                if (existingUser != null)
                    return false;

                await _database.InsertAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> LoginUser(string email, string password)
        {
            try
            {
                return await _database.Table<User>()
                    .Where(u => u.Email == email && u.Password == password)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }
    }
} 