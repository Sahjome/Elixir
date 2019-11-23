using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Elixer.Models;
using System.Threading.Tasks;

namespace Elixer.Services
{
    public class PictureDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public PictureDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pictures>().Wait();
        }

        public Task<Pictures> GetPictureAsync()
        {
            return _database.Table<Pictures>().FirstOrDefaultAsync();
            //return _database.Table<Pictures>().Where(i => i.ID == 1).FirstOrDefaultAsync();
        }

        public Task<int> SavePictureAsync(Pictures pictures)
        {
            if(pictures.ID != 0)
            {
                return _database.UpdateAsync(pictures);
            }
            else
            {
                return _database.InsertAsync(pictures);
            }
        }

        public Task<int> DeletePictureAsync(Pictures pictures)
        {
            return _database.DeleteAsync(pictures);
        }
    }
}
