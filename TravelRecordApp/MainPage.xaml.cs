using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.Models;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.razor.png", assembly);
            
        }

        private async void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {

            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if(isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                var user = (await App.client.GetTable<Users>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;
                    if (user.Password == passwordEntry.Text)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Email or password are incorrect", "Try again");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "There was an error logging you in", "Try again");
                }

            }
        }

        private void signUpButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
