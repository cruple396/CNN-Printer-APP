using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using CNN_App.Tables;


using Xamarin.Forms;

namespace CNN_App.Views
{
    public partial class AddPrinter : ContentPage
    {
        public AddPrinter()
        {
            InitializeComponent();
        }

        //Takes in information from entry and adds a printer to database
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (txtPname != null && txtPbrand != null && txtPtype != null && txtPdetail != null && txtURL != null)
            {

                var path = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PrinterDatabase.db3"));
                var db1 = new SQLiteConnection(path);
                db1.CreateTable<Printers>();
                double price1 = double.Parse(txtPrice.Text);

                var item = new Printers()
                {

                    Name = txtPname.Text,
                    Brand = txtPbrand.Text,
                    Type = txtPtype.Text,
                    Price = price1,
                    Detail = txtPdetail.Text,
                    ImageUrl = txtURL.Text

                };
                db1.Insert(item);


                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = this.DisplayAlert("Success", "Product Added", "Ok");
                    await Shell.Current.GoToAsync($"//adminlog/{nameof(AdminPage)}/{nameof(PrinterInfo)}");
                });
            }

        }
    }
}

