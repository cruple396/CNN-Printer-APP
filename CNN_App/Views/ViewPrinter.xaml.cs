using System;
using SQLite;
using CNN_App.Data;
using System.Collections.Generic;

using Xamarin.Forms;
using CNN_App.Tables;
using System.IO;

namespace CNN_App.Views
{
    [QueryProperty(nameof(itemID), nameof(itemID))]
    public partial class ViewPrinter : ContentPage
    {
        //Takes a printer's id as a string and saves it.
        public string itemID
        {
            get
            {
                return itemID;
            }
            set
            {
                loadPrinter(value);
            }
        }
        public ViewPrinter()
        {
            InitializeComponent();
            BindingContext = new Printers();
        }

        //Printer place holder for the selected printer
        Printers printer;

        //Load the selected printer after converting the string itemID into an int
        async void loadPrinter(string item)
        {
            try
            {
                int id = Convert.ToInt32(item);
                 printer = await App.Database2.GetPrinterAsync(id);
                
                BindingContext = printer;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load printer.");
            }
        }

        //Copies the printer and adds the copy to the CartDatabase
        //Then sends you to the cart
       async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            var path = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CartDatabase.db3"));
            var db2 = new SQLiteConnection(path);
            db2.CreateTable<Printers>();

            

            var item = new Printers()
            {

                Name = printer.Name,
                Price = printer.Price,
                ImageUrl = printer.ImageUrl,
                Type = printer.Type,
                Brand = printer.Brand,
                Detail = printer.Detail


            };
            db2.Insert(item);

            await Shell.Current.GoToAsync($"//products/{nameof(Cart)}");
        }
    }
}

