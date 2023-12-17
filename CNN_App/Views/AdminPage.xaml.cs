using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CNN_App.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }


        // This is a navigation button to go to the User Information page. 
        async void Button_Clicked3(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(UserInfo)}");
            
        }

    
        // This is a navigation button to go to the Printer Information Page.
        async void Button_Clicked2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(PrinterInfo)}");
            
        }

        // This is a navigation tool bar button to go to the administration log-in page. 
        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"//adminlog");
        }

        // This is a navigation button to go to the Order Page.
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(OrderPage)}");
        }
    }
}

