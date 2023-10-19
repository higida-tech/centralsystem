using CentralSystem.ViewModels;

namespace CentralSystem.Views;

public partial class Users : ContentPage
{
	public Users(UserViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}