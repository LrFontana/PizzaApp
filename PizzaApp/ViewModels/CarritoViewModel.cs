using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.ViewModels
{
    public partial class CarritoViewModel : ObservableObject
    {
        // Propiedades.
        public ObservableCollection<ModeloPizza> ModeloPizzas { get; set; } = new();
        public event EventHandler<ModeloPizza> ElementoDelCarritoEliminado;
        public event EventHandler<ModeloPizza> ElementoDelCarritoActualizado;
        public event EventHandler CarritoLimpio;

        [ObservableProperty]
        private double _montoTotal;

        //Constructor.


        // Metodos.

        // Calcular monto total.
        private void RecalcularMontoTotal() => MontoTotal = ModeloPizzas.Sum(p => p.Total);

        // Actualizar carrito.
        [RelayCommand]
        private void ActualizarCarritoItem(ModeloPizza pizza)
        {
            var item = ModeloPizzas.FirstOrDefault( p => p.Nombre == pizza.Nombre );
            if ( item is not null )
            {
                item.CantidadDePizza = pizza.CantidadDePizza;
            }
            else
            {
                ModeloPizzas.Add(pizza.Clone());
            }
            RecalcularMontoTotal();
		}

		// Eliminar item del carrito
		[RelayCommand]
		private async void EliminarItemDelCarrito(string nombre)
        {
			var item = ModeloPizzas.FirstOrDefault(p => p.Nombre == nombre);
			if (item is not null)
			{
				ModeloPizzas.Remove(item);
				RecalcularMontoTotal();

                ElementoDelCarritoEliminado?.Invoke(this, item);

                var opcionesSnakBar = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.PaleGoldenrod
                };
                var snakBar = Snackbar.Make($"'{item.Nombre}' eliminar del carrtio?", () =>
                {
                    ModeloPizzas.Add(item);
                    RecalcularMontoTotal();
					ElementoDelCarritoActualizado?.Invoke(this, item);

				}, "Undo", TimeSpan.FromSeconds(5), opcionesSnakBar);

                await snakBar.Show();
			}
		}

		// Limpiar carrtio
		[RelayCommand]
        private async Task LimpiarCarrito()
        {
            if(await Shell.Current.DisplayAlert("Confirma Limpiar el Carrito?", "Realmente desea eliminar todos los elementos del carrito?", "Si", "No"))
            {
				ModeloPizzas.Clear();
				RecalcularMontoTotal();
                CarritoLimpio?.Invoke(this, EventArgs.Empty);

                await Toast.Make("Carrito Vacio", ToastDuration.Short).Show();
			}       

		}

		// Realizar Pedido
		[RelayCommand]
		private async Task RealizarPedido()
        {
			ModeloPizzas.Clear();
			CarritoLimpio?.Invoke(this, EventArgs.Empty);
			RecalcularMontoTotal();
            await Shell.Current.GoToAsync(nameof(CerrarPagina), animate:true);
		}
	}
}
