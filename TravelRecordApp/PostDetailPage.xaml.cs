using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class PostDetailPage : ContentPage
    {

        Post selectedPost;

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;
            venueLabel.Text = selectedPost.VenueName;
            categoryLabel.Text = selectedPost.CategoryName;
            addressLabel.Text = selectedPost.Address;
            distanceLabel.Text = $"{selectedPost.Distance} m";
        }

        async void updateButton_Clicked(System.Object sender, System.EventArgs e)
        {

            selectedPost.Experience = experienceEntry.Text;

            await App.client.GetTable<Post>().UpdateAsync(selectedPost);
            await DisplayAlert("Success", "Experience succesfully updated", "OK");

            /*
            selectedPost.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience succesfully updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
                }
            }
            */
        }

        async void deleteButton_Clicked(System.Object sender, System.EventArgs e)
        {

            await App.client.GetTable<Post>().DeleteAsync(selectedPost);
            await DisplayAlert("Success", "Experience succesfully deleted", "OK");

            /*
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience succesfully deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
                }
            }
            */
        }
    }
}
