using CentralSystem.ViewModels;

namespace CentralSystem.Views;

public partial class Users : ContentPage
{
	public Users(UsersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}