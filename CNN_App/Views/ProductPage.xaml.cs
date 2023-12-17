using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using CNN_App.Tables;
using System.IO;
using System.Linq;

namespace CNN_App.Views
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        //Gets the Printers in the PrinterDatabase and displays them
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            printer.ItemsSource = await App.Database2.GetPrintersAsync();

        }

        //Printer holder for what the user selects
        Printers selected;

        //Sends the selected printer info to the ViewPrinter Page
        async void printer_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            selected = e.CurrentSelection[0] as Printers;
            await Shell.Current.GoToAsync($"{nameof(ViewPrinter)}?{nameof(ViewPrinter.itemID)}={selected.Num.ToString()}");
        }

        

       
        //Toolbar that sends user to the cart
         async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(Cart)}");
            
        }

        //How the categories pick the type of printers
        async void RadioButton_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            string test = (string)button.Content;
           
             if(test=="Dot Matrix")
            {
                printer.ItemsSource = await App.Database2.QueryDotMatrix();
            }
            else if(test=="Inkjet")
            {
                printer.ItemsSource = await App.Database2.QueryInkjet();
            }
            else if(test=="Laser")
            {
                printer.ItemsSource = await App.Database2.QueryLaser();
            }
             else if(test=="All Printers")
            {
                printer.ItemsSource = await App.Database2.GetPrintersAsync();
            }
        }

      
 

    }

}