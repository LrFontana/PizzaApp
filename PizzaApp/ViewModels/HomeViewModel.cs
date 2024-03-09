namespace PizzaApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        // Propiedades.
        private readonly ServiciosPizza ServiciosPizza;
        public ObservableCollection<ModeloPizza> Pizzas { get; set; }
        // Constructor.
        public HomeViewModel(ServiciosPizza serviciosPizza)
        {
            ServiciosPizza = serviciosPizza;
            Pizzas = new(ServiciosPizza.ObtenerPizzasPopulalres());
        }

        // Metodos.

        // Ir a "TodasLasPizzasPages"
        [RelayCommand]
        private async Task IrATodasLasPizzasPagina(bool terminoDeBusqueda = false)
        {   
            var parametros = new Dictionary<string, object>{[nameof(TodasLasPizzasViewModel.TerminoDeBusqueda)] = terminoDeBusqueda };
            await Shell.Current.GoToAsync(nameof(TodasLasPizzasPage), animate: true, parametros);
        }

		// Ir a "DetallesPage"
		[RelayCommand]
		private async Task IrADetallePage(ModeloPizza pizza)
        {
			var parametros = new Dictionary<string, object> { [nameof(DetalleViewModel.Pizza)] = pizza };
			await Shell.Current.GoToAsync(nameof(DetallesPage), animate: true, parametros);
		}
	}
}
