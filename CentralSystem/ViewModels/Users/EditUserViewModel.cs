using CentralSystem.Models;
using CentralSystem.Repositories;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CentralSystem.ViewModels
{
    [QueryProperty(nameof(User), "User"), QueryProperty(nameof(Users), "Users")]
    public partial class EditUserViewModel: ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private User user;

        [ObservableProperty]
        public ObservableCollection<User> users;

        private readonly LocalDatabase<User> _db;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FormIsValid))]
        private bool nameIsValid;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FormIsValid))]
        private bool emailIsValid;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FormIsValid))]
        private bool phoneIsValid;

        public bool FormIsValid
        {
            get => NameIsValid && EmailIsValid && PhoneIsValid;
        }

        public EditUserViewModel(LocalDatabase<User> database)
        {
            _db = database;
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        public async Task Save()
        {
            var isNew = User.Id == 0;
            await _db.Save(User);
            if (isNew)
            {
                Users.Add(User);
            }
            else
            {
                var idx = Users.ToList().FindIndex(u => u.Id == User.Id);
                Users[idx] = User;
            }
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("User"))
            {
                User = query["User"] as User;
                Title = "Editar Usuário";
            }
            else
            {
                User = new User();
                Title = "Novo Usuário";
            }

            Users = query["Users"] as ObservableCollection<User>;
        }
    }
}
