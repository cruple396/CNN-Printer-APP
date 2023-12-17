using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using CNN_App.Tables;

namespace CNN_App.Views
{
    public partial class RegPage : ContentPage
    {
        public RegPage()
        {
            InitializeComponent();
        }

        //Takes in information from the entries and inserts the user
        void Handle_Clicked(object sender, System.EventArgs e)
        {


            if (userNameEntry != null && emailEntry != null && passwordEntry != null)
            {

                var path = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3"));
                var db1 = new SQLiteConnection(path);
                db1.CreateTable<RegUser>();

                var item = new RegUser()
                {

                    Username = userNameEntry.Text,
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text,
                    Admin = ""

                };
                db1.Insert(item);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = this.DisplayAlert("Congradulations", "Registeration Sucessfull", "Ok");

                    await Shell.Current.GoToAsync($"//loginpage");
                });

            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result3 = this.DisplayAlert("Error", "Make sure all information is entered", "Ok");
                    await Shell.Current.GoToAsync($"//loginpage/{nameof(RegPage)}");
                });
            }

        }

    }
}

