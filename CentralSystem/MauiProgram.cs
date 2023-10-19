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

        builder.Services.AddTransient<Users>();
        builder.Services.AddTransient<UsersViewModel>();

        builder.Services.AddTransient<EditUser>();
        builder.Services.AddTransient<EditUserViewModel>();

		builder.Services.AddTransient<LocalDatabase<User>>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
