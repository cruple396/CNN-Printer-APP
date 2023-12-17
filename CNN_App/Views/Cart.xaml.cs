using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CNN_App.Tables;
using CNN_App.Data;
using Xamarin.Forms;
using SQLite;
using System.Reflection;

namespace CNN_App.Views
{
    public partial class Cart : ContentPage
    {
        public Cart()
        {
            InitializeComponent();
            BindingContext = this;
        }

        // This is where the information is gathered from the cart database and
        // displayed in the collection view.
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            temp.ItemsSource = await App.Database3.GetCartssAsync();
        }

        //This button navigates to the checkout page.
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        
            
            await Shell.Current.GoToAsync($"{nameof(Checkout)}");
        }

        // This swipe removes the printer from the cart by deleting it. 
        async void SwipeItem_Invoked(System.Object sender, System.EventArgs e)
        {
            if(selected!=null)
            {
                await App.Database3.DeleteItemAsync(selected);

                temp.ItemsSource = await App.Database3.GetCartssAsync();
            }
          
        }

        //This is the printers place-holder for selected printer.
        Printers selected;
        void temp_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {                           
                selected = e.CurrentSelection[0] as Printers;
            
        }

        
    }
}

