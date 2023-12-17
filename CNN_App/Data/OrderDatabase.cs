using System;
using CNN_App.Tables;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;
using SQLite;

namespace CNN_App.Data
{
    public class OrderDatabase
    {
        readonly SQLiteAsyncConnection db3;
        public OrderDatabase(string dbpath3)
        {
            db3 = new SQLiteAsyncConnection(dbpath3);
            db3.CreateTableAsync<Orders>().Wait();

        }
        //Get all orders in the order OrderDatabase
        public Task<List<Orders>> GetOrdersAsync()
        {
            return db3.Table<Orders>().ToListAsync();
        }

        //Delete am order
        public Task<int> DeleteOrdersAsync(Orders order)
        {
            return db3.DeleteAsync(order);

        }

        //Add an order
        public Task<int> AddOrderAsync(Orders order)
        {
            return db3.InsertAsync(order);
        }

        //Get a specific order
        public Task<Orders> GetPrinterAsync(int id)
        {
            return db3.Table<Orders>().Where(i => i.orderNum == id).FirstOrDefaultAsync();
        }

       

    }
}

