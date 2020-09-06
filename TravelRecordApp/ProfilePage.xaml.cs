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

            var postTable = await Post.Read();

            var namesCount = Post.PostCategories(postTable);

                namesListView.ItemsSource = namesCount;

                postCountLabel.Text = postTable.Count.ToString();
            //}
        }
        
    }
}
