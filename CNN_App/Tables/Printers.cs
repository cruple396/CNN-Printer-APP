using SQLite;
using Xamarin.Forms;

namespace CNN_App.Tables
{
    public class Printers
    {
        [PrimaryKey, AutoIncrement]
        public int Num { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }

        

    }
}

