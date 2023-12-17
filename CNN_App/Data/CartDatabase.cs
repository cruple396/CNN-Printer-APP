using System;
using CNN_App.Tables;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CNN_App.Data
{
    public class CartDatabase
    {
        readonly SQLiteAsyncConnection db2;
        public CartDatabase(string dbpath2)
        {
            db2 = new SQLiteAsyncConnection(dbpath2);
            db2.CreateTableAsync<Printers>().Wait();

        }

        //Get all printers in cart
        public Task<List<Printers>> GetCartssAsync()
        {
            return db2.Table<Printers>().ToListAsync();
        }

        
        //Get a specific printer from cart
        public Task<Printers> GetCartAsync(int id)
        {
            return db2.Table<Printers>().Where(i => i.Num == id).FirstOrDefaultAsync();
        }

        //Delete a printer from cart
        public Task<int> DeleteItemAsync(Printers printer)
        {
            return db2.DeleteAsync(printer);

        }

        //Add a printer to cart
        public Task<int> AddPCartAsync(Printers printer)
        {
            return db2.InsertAsync(printer);
        }



       //Delete all printers from the cart
        public  Task<int>DeleteAllItemsAsync<T>()
        {
            return  db2.DeleteAllAsync<Printers>();
        }

        

    }

       
}

