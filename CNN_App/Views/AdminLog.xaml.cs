using System;
using System.IO;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using CNN_App.Tables;

namespace CNN_App.Views
{
    public partial class AdminLog : ContentPage
    {
        public AdminLog()
        {
            InitializeComponent();
        }

        // If these are in the database and are in the admin roll it sends them to the admin page. 
        async void Handle_Clicked(object sender, EventArgs e)
        {
            var dbpath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3"));
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUser>().Where(u => u.Username.Equals(userNameEntry.Text) && u.Password.Equals(passwordEntry.Text) && u.Admin.Equals("Admin")).FirstOrDefault();

            if (myquery != null)
            {
                
                    await Shell.Current.GoToAsync($"{nameof(AdminPage)}");
                
                
            }
            else   // if not in the database this will send an error message.
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = this.DisplayAlert("Error", "Invalid Credentials", "Ok");
                    await Shell.Current.GoToAsync($"//adminlog");

                    
                });
            }
        }
    }
}

