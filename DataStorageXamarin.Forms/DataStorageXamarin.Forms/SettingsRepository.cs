using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DataStorageXamarin.Forms
{
    public class SettingsRepository
    {
        SQLiteConnection conn;
        SQLiteAsyncConnection asyncConnection;
        public string StatusMessage { get; set; }

        public SettingsRepository(string dbPath, bool async)
        {
            if (async)
            {
                asyncConnection = new SQLiteAsyncConnection(dbPath);
                asyncConnection.CreateTableAsync<SettingsModel>().Wait();
            }
            else
            {
                conn = new SQLiteConnection(dbPath);
                conn.CreateTable<SettingsModel>();
            }

        }

        public void AddNewSettings(string key, string value)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(key))
                    throw new Exception("Valid key required");

                result = conn.Insert(new SettingsModel { Key = key, Value = value });

                StatusMessage = string.Format("{0} record(s) added [Key: {1})", result, key);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", key, ex.Message);
            }
        }

        public List<SettingsModel> GetAllSettings()
        {
            try
            {
                return conn.Table<SettingsModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<SettingsModel>();
        }

        public async Task AddNewSettingsAsync(string key, string value)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(key))
                    throw new Exception("Valid key required");

                result = await asyncConnection.InsertAsync(new SettingsModel { Key = key, Value = value });

                StatusMessage = string.Format("{0} record(s) added [Key: {1})", result, key);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", key, ex.Message);
            }
        }

        public async Task<List<SettingsModel>> GetAllSettingsAsync()
        {
            try
            {
                return await asyncConnection.Table<SettingsModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<SettingsModel>();
        }

        public async Task<SettingsModel> GetSettingsAsync(string key)
        {
            try
            {
                SettingsModel sm = await asyncConnection.Table<SettingsModel>().Where(s=> s.Key == key).FirstOrDefaultAsync();

                return sm;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new SettingsModel();
        }

        public async Task UpdateSettingsAsync(string key, string value)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(key))
                    throw new Exception("Valid key required");

                SettingsModel settingsModel = await GetSettingsAsync(key);
                if (settingsModel==null)
                {
                    throw new Exception("Invalid Data For update");
                }

                result = await asyncConnection.UpdateAsync(new SettingsModel { Key = key, Value = value });

                StatusMessage = string.Format("{0} record(s) added [Key: {1})", result, key);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", key, ex.Message);
            }
        }
    }
}
