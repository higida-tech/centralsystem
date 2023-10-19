using CentralSystem.Views;
namespace CentralSystem;

public partial class MainPage : Shell
{
	public MainPage()
	{
        InitializeComponent();
        Routing.RegisterRoute("editUser", typeof(EditUser));
    }
}

