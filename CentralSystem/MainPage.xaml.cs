using CentralSystem.Views;
namespace CentralSystem;

public partial class MainPage : Shell
{
	public MainPage()
	{
        InitializeComponent();
        Routing.RegisterRoute("users/edit", typeof(EditUser));
        Routing.RegisterRoute("customers/edit", typeof(EditCustomer));
        Routing.RegisterRoute("products/edit", typeof(EditProduct));
    }
}

