using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
    public class Users : INotifyPropertyChanged
    {
        public Users()
        {
        }

        public string Id
        {
            get { return Id; }
            private set {
                Id = value;
                OnPropertyChanged("Id");      
            }
        }
        public string Email
        {
            get { return Email; }
            private set
            {
                Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password
        {
            get { return Password; }
            private set
            {
                Password = value;
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async Task<bool> Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                var user = (await App.client.GetTable<Users>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;
                    if (user.Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
        }

        public static async void Register(Users user)
        {
            await App.client.GetTable<Users>().InsertAsync(user);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
