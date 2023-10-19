using CentralSystem.Models;
using CentralSystem.Repositories;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CentralSystem.ViewModels
{
    public partial class UsersViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<User> users;

        private readonly LocalDatabase<User> _db;
        public UsersViewModel(LocalDatabase<User> database) {
            _db = database;
        }

        [RelayCommand]
        public async Task AddUser()
        {
            var dict = new Dictionary<string, object>
            {
                { "Users", Users }
            };
            await Shell.Current.GoToAsync("editUser", dict);
        }

        [RelayCommand]
        public async Task GetUsers()
        {
            Users = new ObservableCollection<User>(await _db.GetAll());
        }

        [RelayCommand]
        public async Task DeleteUser(int id)
        {
            var user = Users.Where(u => u.Id == id).FirstOrDefault();
            Users.Remove(user);
            await _db.Delete(user);
        }

        [RelayCommand]
        public async Task EditUser(int id)
        {
            var user = Users.Where(u => u.Id == id).FirstOrDefault().Clone() as User;
            var dict = new Dictionary<string, object>
            {
                { "User", user },
                { "Users", Users }
            };
            await Shell.Current.GoToAsync("editUser", dict);
        }
    }
}
