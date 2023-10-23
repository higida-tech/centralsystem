using CentralSystem.ViewModels;

namespace CentralSystem.Views;

public partial class Products : ContentPage
{
	public Products(ProductViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}