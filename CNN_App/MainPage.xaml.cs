using Xamarin.Forms;
using System;
using System.Collections.Generic;
using CNN_App.Views;

namespace CNN_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(RegPage), typeof(RegPage));
            Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
            Routing.RegisterRoute(nameof(UserInfo), typeof(UserInfo));
            Routing.RegisterRoute(nameof(EditPrinter), typeof(EditPrinter));
            Routing.RegisterRoute(nameof(AddPrinter), typeof(AddPrinter));
            Routing.RegisterRoute(nameof(ViewPrinter), typeof(ViewPrinter));
            Routing.RegisterRoute(nameof(PrinterInfo), typeof(PrinterInfo));
            Routing.RegisterRoute(nameof(Cart), typeof(Cart));
            Routing.RegisterRoute(nameof(Checkout), typeof(Checkout));
            Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        }
    }
}

