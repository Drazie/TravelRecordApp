using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        private async void registerButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                //we can register the user

                Users user = new Users()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text,

                };

                Users.Register(user);
            }
            else
            {
                await DisplayAlert("Error", "Passwords do not match", "OK");
            }
        }
    }
}
