using CentralSystem.ViewModels;
namespace CentralSystem.Views;

public partial class Customers : ContentPage
{
    public Customers(CustomerViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}