using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using CNN_App.Tables;
using Xamarin.Forms;

namespace CNN_App.Views
{
    public partial class Checkout : ContentPage
    {
        public Checkout()
        {
            InitializeComponent();
        }
        
        // This is a button that saves a order with a random number to a cart database
        // and deletes everything inside the cart.
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();

            int random_Num = rand.Next(1000000, 9999999);


            var path = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OrderDatabase.db3"));
            var db4 = new SQLiteConnection(path);
            db4.CreateTable<Orders>();

            var item = new Orders()
            {
                randNum = random_Num
            };

            db4.Insert(item);


           await App.Database3.DeleteAllItemsAsync<Printers>();
            await Shell.Current.GoToAsync($"//products");
        }
    }
}

