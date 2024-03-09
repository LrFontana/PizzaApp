namespace PizzaApp.Pages;

public partial class TodasLasPizzasPage : ContentPage
{
    // Propiedades.
    private readonly TodasLasPizzasViewModel _todasLasPizzasviewModel;
    
    // Constructor.
    public TodasLasPizzasPage(TodasLasPizzasViewModel todasLasPizzasViewModel)
	{
		InitializeComponent();
		_todasLasPizzasviewModel = todasLasPizzasViewModel;
        BindingContext = _todasLasPizzasviewModel;
	}

	// Metodos.

    // OnAppearing
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if (_todasLasPizzasviewModel.TerminoDeBusqueda)
		{
			await Task.Delay(100);
			barraDeBusqueda.Focus();
		}
	}

	// barra de busqueda.
	void BarraDeBusqueda_ElTextoCambio(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _todasLasPizzasviewModel.BuscarPizzasCommand.Execute(null);
        }
    }
}