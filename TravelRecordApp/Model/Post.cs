using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        public string Id
        {
            get { return Id; }
            private set {
                Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Experience
        {
            get { return Experience; }
            private set
            {
                Experience = value;
                OnPropertyChanged("Experience");
            }
        }

        public string VenueName
        {
            get { return VenueName; }
            private set
            {
                VenueName = value;
                OnPropertyChanged("VenueName");
            }
        }

        public string CategoryId
        {
            get { return CategoryId; }
            private set
            {
                CategoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        public string CategoryName
        {
            get { return CategoryName; }
            private set
            {
                CategoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        public double Latitude
        {
            get { return Latitude; }
            private set
            {
                Latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        public double Longitude
        {
            get { return Longitude; }
            private set
            {
                Longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        public int Distance
        {
            get { return Distance; }
            private set
            {
                Distance = value;
                OnPropertyChanged("Distance");
            }
        }

        public string Address
        {
            get { return Address; }
            private set
            {
                Address = value;
                OnPropertyChanged("Address");
            }
        }

        public string UserId
        {
            get { return UserId; }
            private set
            {
                UserId = value;
                OnPropertyChanged("UserId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Insert(Post post)
        {
            await App.client.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
            var posts = await App.client.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();
            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var venuesNames = (from p in posts
                               orderby p.CategoryId
                               select p.VenueName).Distinct().ToList();

            Dictionary<string, int> namesCount = new Dictionary<string, int>();
            foreach (var name in venuesNames)
            {
                var count = (from post in posts
                             where post.VenueName == name
                             select post).ToList().Count;

                namesCount.Add(name, count);
            }

            return namesCount;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
