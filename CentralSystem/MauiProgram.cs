using CentralSystem.Views;
using CommunityToolkit.Maui;
using CentralSystem.ViewModels;
using Microsoft.Extensions.Logging;
using CentralSystem.Models;
using CentralSystem.Repositories;

namespace CentralSystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FA-Brands-Regular-400.otf", "FAB");
                fonts.AddFont("FA-Free-Regular-400.otf", "FAR");
                fonts.AddFont("FA-Free-Solid-900.otf", "FAS");
            });

        /* Users */
        builder.Services.AddTransient<Users>();
        builder.Services.AddTransient<UserViewModel>();
        builder.Services.AddTransient<EditUser>();
        builder.Services.AddTransient<EditUserViewModel>();

        /* Customers */
        builder.Services.AddTransient<Customers>();
        builder.Services.AddTransient<CustomerViewModel>();
        builder.Services.AddTransient<EditCustomer>();
        builder.Services.AddTransient<EditCustomerViewModel>();

        /* Products */
        builder.Services.AddTransient<Products>();
        builder.Services.AddTransient<ProductViewModel>();
        builder.Services.AddTransient<EditProduct>();
        builder.Services.AddTransient<EditProductViewModel>();

        builder.Services.AddTransient<LocalDatabase<User>>();
        builder.Services.AddTransient<LocalDatabase<Customer>>();
        builder.Services.AddTransient<LocalDatabase<Product>>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
