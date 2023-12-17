using System;
using CNN_App.Tables;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CNN_App.Data
{
    public class PrinterDatabase
    {
        readonly SQLiteAsyncConnection db1;
        public PrinterDatabase(string dbpath1)
        {
            db1 = new SQLiteAsyncConnection(dbpath1);
            db1.CreateTableAsync<Printers>().Wait();

        }

        //Get all printers from the PrinterDatabase
        public Task<List<Printers>> GetPrintersAsync()
        {
            return db1.Table<Printers>().ToListAsync();
        }

        //Update information for a printer
        public Task<int> UpdatePrinterAsync(Printers printer)
        {
            return db1.UpdateAsync(printer);

        }

        //Get a specific printer
        public Task<Printers> GetPrinterAsync(int id)
        {
            return db1.Table<Printers>().Where(i => i.Num == id).FirstOrDefaultAsync();
        }

        //Delete a printer
        public Task<int> DeletePrinterAsync(Printers printer)
        {
            return db1.DeleteAsync(printer);

        }

        //Add a printer
        public Task<int>AddPrinterAsync(Printers printer)
        {
            return db1.InsertAsync(printer);
        }


        //Categories for types of printers
        public Task<List<Printers>> QueryLaser()
        {
            
            return db1.Table<Printers>().Where(p => p.Type == "Laser").ToListAsync();
        }

        public Task<List<Printers>> QueryInkjet ()
        {
            return db1.Table<Printers>().Where(p => p.Type == "Inkjet").ToListAsync();
        }

        public Task<List<Printers>>QueryDotMatrix ()
        {
            return db1.Table<Printers>().Where(p => p.Type == "Dot Matrix").ToListAsync();
        }

      


    }
}

