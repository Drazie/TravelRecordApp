using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {

            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post post = new Post()
                {
                    Experience = experienceEntry.Text,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = selectedVenue.location.address,
                    Distance = selectedVenue.location.distance,
                    Latitude = selectedVenue.location.lat,
                    Longitude = selectedVenue.location.lng,
                    VenueName = selectedVenue.name
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Insert(post);

                    if (rows > 0)
                    {
                        DisplayAlert("Success", "Experience succesfully inserted", "Ok");
                    }
                    else
                    {
                        DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
                    }
                }
            }
            catch (NullReferenceException nre)
            {
                DisplayAlert("Error", "404", "Cancel");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Something went wrong", "Cancel");
            }

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);

            venueListView.ItemsSource = venues;
        }
    }
}
