using CentralSystem.ViewModels;

namespace CentralSystem.Views;

public partial class EditProduct : ContentPage
{
	public EditProduct(EditProductViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}