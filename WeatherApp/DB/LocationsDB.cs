using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WeatherApp.Model;

namespace WeatherApp.DB
{
    public class LocationsDB
    {
        private readonly SQLiteAsyncConnection database;

        public LocationsDB()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserLocations.db");
            database = new SQLiteAsyncConnection(dbPath);

            // create if not existing
            database.CreateTableAsync<UserLocation>().Wait();
        }

        public Task<List<UserLocation>> GetItemsAsync()
        {
            return database.Table<UserLocation>().ToListAsync();
        }

        /*
         * Query con statement SQL.
         */
        public Task<List<UserLocation>> GetItemsWithWhere(string id)
        {
            return database.QueryAsync<UserLocation>("SELECT * FROM [UserLocations] WHERE [Id] =?", id);
        }

        /*
         * Query con LINQ.
         */
        public Task<UserLocation> GetItemAsync(string id)
        {
            return database.Table<UserLocation>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        /*
         * Salvataggio o update.
         */
        public Task<int> SaveItemAsync(UserLocation item)
        {
            return database.InsertAsync(item);
        }

        /*
         * Cancellazione di un elemento.
         */
        public Task<int> DeleteItemAsync(UserLocation item)
        {
            return database.DeleteAsync(item);
        }

    }
}
