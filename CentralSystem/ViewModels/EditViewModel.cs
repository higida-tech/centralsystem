using CentralSystem.Models;
using CentralSystem.Repositories;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CentralSystem.ViewModels
{
    public partial class EditViewModel<T> : ObservableObject, IQueryAttributable where T:BaseModel, new()
    {
        private readonly string tname;

        [ObservableProperty]
        private T item;

        [ObservableProperty]
        public ObservableCollection<T> items;

        private readonly LocalDatabase<T> _db;

        public EditViewModel(LocalDatabase<T> database)
        {
            _db = database;
            tname = typeof(T).Name;
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        public async Task Save()
        {
            var isNew = Item.Id == 0;
            await _db.Save(Item);
            if (isNew)
            {
                Items.Add(Item);
            }
            else
            {
                var idx = Items.ToList().FindIndex(u => u.Id == Item.Id);
                Items[idx] = Item;
            }
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(tname))
            {
                Item = query[tname] as T;
            }
            else
            {
                Item = new T();
            }

            Items = query[$"{tname}s"] as ObservableCollection<T>;
        }
    }

    public sealed class EditUserViewModel : EditViewModel<User>
    {
        public EditUserViewModel(LocalDatabase<User> database) : base(database) { }
    }

    public sealed class EditCustomerViewModel : EditViewModel<Customer>
    {
        public EditCustomerViewModel(LocalDatabase<Customer> database) : base(database) { }
    }
}
