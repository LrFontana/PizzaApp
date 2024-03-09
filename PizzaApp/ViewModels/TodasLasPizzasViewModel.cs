using CommunityToolkit.Mvvm.Input;

namespace PizzaApp.ViewModels
{
    [QueryProperty(nameof(TerminoDeBusqueda), nameof(TerminoDeBusqueda))]
    public partial class TodasLasPizzasViewModel : ObservableObject
    {
        // Propiedades.
        public ObservableCollection<ModeloPizza> Pizzas { get; set; }
        private readonly ServiciosPizza _serviciosPizza;

        [ObservableProperty]
        private bool _terminoDeBusqueda;

		[ObservableProperty]
		private bool _buscando;

        // Constructor.
        public TodasLasPizzasViewModel(ServiciosPizza serviciosPizza)
        {
            _serviciosPizza = serviciosPizza;
            Pizzas = new(_serviciosPizza.ObtenerTodasasPizzas());
        }
        // Metodos.

        // Buscar Pizza.
        [RelayCommand]
        private async Task BuscarPizzas(string terminoDeBusqueda)
        {
            Pizzas.Clear();
            Buscando = true;
            await Task.Delay(1000);
            foreach (var pizzas in _serviciosPizza.ObtenerPizzasByParam(terminoDeBusqueda))
            {
                Pizzas.Add(pizzas);
            }
            Buscando= false;
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
