using CentralSystem.ViewModels;

namespace CentralSystem.Views;

public partial class EditUser : ContentPage
{
    public EditUser(EditUserViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}