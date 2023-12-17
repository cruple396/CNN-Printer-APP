using System;
using SQLite;
using System.Collections.Generic;
using CNN_App.Tables;

using Xamarin.Forms;

namespace CNN_App.Views
{
    [QueryProperty (nameof(itemID), nameof(itemID))]
    public partial class EditPrinter : ContentPage
    {
        //Takes a printer ID as a string
        public string itemID
        {
            set
            {
                loadPrinter(value);
            }
        }

        public EditPrinter()
        {
            InitializeComponent();
            BindingContext = new Printers();
        }

        //Printer holder
        Printers printer;
        //Converts the itemID string into an int and loads the printer with that ID
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

        //Puts the printers information into the entries. Converts txtPrice.Text into a double
        //Saves the edited informtaion into that printer's table
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            double price1 = double.Parse(txtPrice.Text);

            var printer = (Printers)BindingContext;

            printer.Name = txtPname.Text;
            printer.Brand = txtPbrand.Text;
            printer.Type = txtPtype.Text;
            printer.Price = price1;
            printer.Detail = txtPdetail.Text;
            printer.ImageUrl = txtURL.Text;

            await App.Database2.UpdatePrinterAsync(printer);
            await Shell.Current.GoToAsync($"//adminlog/{nameof(AdminPage)}/{nameof(PrinterInfo)}");
        }

        //Delete the selected printer and update the list
        async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            await App.Database2.DeletePrinterAsync(printer);
            await App.Database2.GetPrintersAsync();
            await Shell.Current.GoToAsync($"//adminlog/{nameof(AdminPage)}/{nameof(PrinterInfo)}");
        }
    }
}

