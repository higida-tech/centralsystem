using CentralSystem.ViewModels;

namespace CentralSystem.Views;

public partial class EditCustomer : ContentPage
{
	public EditCustomer(EditCustomerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}