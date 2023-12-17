using System;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using CNN_App.Tables;

namespace CNN_App.Views
{
    public partial class UserInfo : ContentPage
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        //Gets the list of users from the UserDatagase
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            user.ItemsSource = await App.Database.GetUsersAsync();

        }

        //RugUser holder for the selected user
        //Fills in the entries with the users information
        RegUser lastSelection;
        void user_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as RegUser;

            txtUsername.Text = lastSelection.Username;
            txtAdmin.Text = lastSelection.Admin;
        }

        //Button to update the user information from what is in the entries
        async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (txtUsername != null)
            {
                lastSelection.Username = txtUsername.Text;
                lastSelection.Admin = txtAdmin.Text;

                await App.Database.UpdateUserAsync(lastSelection);
                user.ItemsSource = await App.Database.GetUsersAsync();
            }
        }

        //Delete the selected user from the UserDatabase
        async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (lastSelection != null)
            {
                await App.Database.DeleteUserAsync(lastSelection);

                user.ItemsSource = await App.Database.GetUsersAsync();

                txtUsername.Text = "";
                txtAdmin.Text = "";
            }
        }

    }
}

