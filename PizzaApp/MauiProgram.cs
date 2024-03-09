using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PizzaApp.Pages;
using PizzaApp.Servicios;
using PizzaApp.ViewModels;

namespace PizzaApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.UseMauiCommunityToolkit();

#if DEBUG
			builder.Logging.AddDebug();
#endif
			AgregarServiciosPizza(builder.Services);

			return builder.Build();
		}

		private static IServiceCollection AgregarServiciosPizza(IServiceCollection servicios)
		{
			servicios.AddSingleton<ServiciosPizza>();
			servicios.AddSingleton<HomePage>().AddSingleton<HomeViewModel>();

			servicios.AddTransientWithShellRoute<TodasLasPizzasPage, TodasLasPizzasViewModel>(nameof(TodasLasPizzasPage));

			servicios.AddTransientWithShellRoute<DetallesPage, DetalleViewModel>(nameof(DetallesPage));
			
			servicios.AddSingleton<CarritoViewModel>();
			servicios.AddTransient<CarritoPage>();
			return servicios;
		}
	}
}
