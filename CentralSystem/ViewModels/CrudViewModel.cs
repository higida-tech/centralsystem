using CentralSystem.Models;
using CentralSystem.Repositories;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CentralSystem.ViewModels
{
    public partial class CrudViewModel<T> : ObservableObject where T: BaseModel, new()
    {
        private readonly string tname;

        [ObservableProperty]
        private ObservableCollection<T> items;

        private readonly LocalDatabase<T> _db;
        public CrudViewModel(LocalDatabase<T> database)
        {
            _db = database;
            tname = typeof(T).Name;
        }

        [RelayCommand]
        public async Task Add()
        {
            var dict = new Dictionary<string, object>
            {
                [$"{tname}s"] = Items
            };

            await Shell.Current.GoToAsync("edit", dict);
        }

        [RelayCommand]
        public async Task Get()
        {
            Items = new ObservableCollection<T>(await _db.GetAll());
        }

        [RelayCommand]
        public async Task Delete(int id)
        {
            var item = Items.Where(u => u.Id == id).FirstOrDefault();
            Items.Remove(item);
            await _db.Delete(item);
        }

        [RelayCommand]
        public async Task Edit(int id)
        {
            var item = Items.Where(u => u.Id == id).FirstOrDefault().Clone() as T;
            var dict = new Dictionary<string, object>
            {
                [tname] = item,
                [$"{tname}s"] = Items
            };
            await Shell.Current.GoToAsync("edit", dict);
        }
    }

    public sealed class UserViewModel : CrudViewModel<User>
    {
        public UserViewModel(LocalDatabase<User> database) : base(database) {}
    }

    public sealed class CustomerViewModel : CrudViewModel<Customer>
    {
        public CustomerViewModel(LocalDatabase<Customer> database) : base(database) { }
    }

    public sealed class ProductViewModel : CrudViewModel<Product>
    {
        public ProductViewModel(LocalDatabase<Product> database) : base(database) { }
    }
}
