#if IOS
using UIKit;
#endif

using CommunityToolkit.Maui.Behaviors;

namespace PizzaApp.Pages;

public partial class DetallesPage : ContentPage
{
	// Propiedades.
	private readonly DetalleViewModel _detalleViewModel;

	// Constructor.
	public DetallesPage(DetalleViewModel detalleViewModel)
	{
		InitializeComponent();
		_detalleViewModel = detalleViewModel;
		BindingContext = _detalleViewModel;
	}

	// Metodos.

	// OnAppearing
	protected override void OnAppearing()
	{
		base.OnAppearing();
#if IOS
		var boton = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;

		BotonCarrito.Margin = new Thickness(-1, 0, -1, (boton+1) * -1);
#endif
	}

	// Click boton imagen.
	async void ImagenBoton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..", animate: true);
	}

	// Navegar desde...
	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		Behaviors.Add(new StatusBarBehavior()
		{
			StatusBarColor = Colors.DarkGoldenrod,
			StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent
		});
	}
}