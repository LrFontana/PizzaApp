namespace PizzaApp.Pages;

public partial class CarritoPage : ContentPage
{
	// Propiedades.
	private readonly CarritoViewModel _carritoViewModel;

	// Constructor.
	public CarritoPage(CarritoViewModel carritoViewModel)
	{
		InitializeComponent();
		_carritoViewModel = carritoViewModel;
		BindingContext = _carritoViewModel;
	}

	// Metodos.

	// Boton Click.
	async void Boton_Clickeado(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(TodasLasPizzasPage));
	}
}