using System;
using System.IO;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using CNN_App.Tables;

namespace CNN_App.Views
{
    public partial class LoginUser : ContentPage
    {
        
        public LoginUser()
        {
            InitializeComponent();

        }
       
        // This is a tap gesture that goes to the register page. 
        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//loginpage/{nameof(RegPage)}");
        }

         // This is if the user is in the database with the correct information
         // that goes to the product page.
         async void Handle_Clicked(object sender, EventArgs e)
        {
            var dbpath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3"));
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUser>().Where(u => u.Username.Equals(userNameEntry.Text) && u.Password.Equals(passwordEntry.Text)).FirstOrDefault();

            if (myquery != null)
            {
                await Shell.Current.GoToAsync($"//products");
            }
            else
            {

                Device.BeginInvokeOnMainThread( async() =>
                {
                    var result = this.DisplayAlert("Error", "Invalid Credentials", "Ok");
                    await Shell.Current.GoToAsync($"//loginpage");




                });
            }
        }
    }
}

