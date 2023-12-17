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
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        // This is a placeholder for selected user.
        Orders selected;
        void order_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            selected = e.CurrentSelection[0] as Orders;

        }

        // Displays all the orders in the order database.
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            order.ItemsSource = await App.Database4.GetOrdersAsync();

        }

        // Deletes the selected order and refresh the list.
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (selected != null)
            {
                await App.Database4.DeleteOrdersAsync(selected);

                order.ItemsSource = await App.Database4.GetOrdersAsync();

               
            }
        }
    }
}

