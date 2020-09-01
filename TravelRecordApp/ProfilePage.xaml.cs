using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //var postTable = conn.Table<Post>().ToList();

            var postTable = await App.client.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();

            var venuesNames = (from p in postTable
                                  orderby p.CategoryId
                                  select p.VenueName).Distinct().ToList();

                Dictionary<string, int> namesCount = new Dictionary<string, int>();
                foreach (var name in venuesNames)
                {
                    var count = (from post in postTable
                                 where post.VenueName == name
                                 select post).ToList().Count;

                    namesCount.Add(name, count);
                }

                namesListView.ItemsSource = namesCount;

                postCountLabel.Text = postTable.Count.ToString();
            //}
        }
        
    }
}
