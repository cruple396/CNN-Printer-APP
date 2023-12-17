 using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using CNN_App.Tables;

namespace CNN_App.Data
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection db;
        public UserDatabase(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            db.CreateTableAsync<RegUser>().Wait();

        }

        //Get all userers
        public Task<List<RegUser>> GetUsersAsync()
        {
            return db.Table<RegUser>().ToListAsync();
        }

        //Update information for the user
        public Task<int> UpdateUserAsync(RegUser user)
        {
            return db.UpdateAsync(user);

        }

        //Get a specific user
        public Task<RegUser> GetUserAsync(string username)
        {
            return db.Table<RegUser>().Where(i => i.Username == username).FirstOrDefaultAsync();
        }

        //Delete a user
        public Task<int> DeleteUserAsync(RegUser user)
        {
            return db.DeleteAsync(user);

        }
    }
}

