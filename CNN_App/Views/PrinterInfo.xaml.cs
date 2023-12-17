using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CNN_App.Tables;
using SQLite;
using Xamarin.Forms;

namespace CNN_App.Views
{
    public partial class PrinterInfo : ContentPage
    {
        public PrinterInfo()
        {
            InitializeComponent();
            BindingContext = this;
        }

        //Puts the printers from the PrinterDatabase into the collection view
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            printer.ItemsSource = await App.Database2.GetPrintersAsync();

        }

        //Printer holder for what the user selects
        Printers selected;

        //Sends and goes to teh EditPrinter page with the selected printo info
        async void printer_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            selected = e.CurrentSelection[0] as Printers;
            await Shell.Current.GoToAsync($"{nameof(EditPrinter)}?{nameof(EditPrinter.itemID)}={selected.Num.ToString()}");
        }

        
        //Goes to the AddPrinter page
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(AddPrinter)}");
        }

    }
}



