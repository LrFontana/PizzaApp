namespace PizzaApp.Pages;

public partial class CerrarPagina : ContentPage
{
	// Propiedades.


	// Constructor.
	public CerrarPagina()
	{
		InitializeComponent();
	}


	// Metodos.

	// "Override" OnAppearing
	protected override async void OnAppearing()
	{
		base.OnAppearing();

		img.ScaleTo(1.5);
		mensaje.ScaleTo(1);

		await img.ScaleTo(0.5);
		await img.ScaleTo(1.5);
		await img.ScaleTo(0.5);
		await img.ScaleTo(1.5);
		await img.ScaleTo(0.5);
		await img.ScaleTo(1.5);
		await img.ScaleTo(1);

		Boton_Inicio.FadeTo(1, length: 500);
		await Boton_Inicio.ScaleTo(1);
	}


	// Click boton inicio.
	private async void Click_BotonDeInicio(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}", animate:true);
	}
}