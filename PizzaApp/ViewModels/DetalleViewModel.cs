using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.ViewModels
{
	[QueryProperty(nameof(Pizza), nameof(Pizza))]
	public partial class DetalleViewModel : ObservableObject, IDisposable
	{
		// Propiedades.
		[ObservableProperty]
		private ModeloPizza _pizza;
		private readonly CarritoViewModel _carritoViewModel;

        // Constructor.
        public DetalleViewModel(CarritoViewModel carritoViewModel)
        {
            _carritoViewModel = carritoViewModel;

			_carritoViewModel.CarritoLimpio += OnCarritoLimpio;
			_carritoViewModel.ElementoDelCarritoActualizado += OnItemCarritoEliminado;
			_carritoViewModel.ElementoDelCarritoActualizado += OnItemCarritoActualizado;

		}

		// Metodos

		// Agregar al carrito
		[RelayCommand]
		private void AgregarAlCarrito()
		{
			Pizza.CantidadDePizza++;
			_carritoViewModel.ActualizarCarritoItemCommand.Execute(Pizza);
		}

		// Eliminar del carrito
		[RelayCommand]
		private void EliminarDelCarrito()
		{
			if (Pizza.CantidadDePizza > 0)
			{
				Pizza.CantidadDePizza--;
				_carritoViewModel.ActualizarCarritoItemCommand.Execute(Pizza);
			}
				 
		}

		// Ver Carrito
		[RelayCommand]
		private async Task VerCarrito()
		{
			if (Pizza.CantidadDePizza > 0)
			{
				await Shell.Current.GoToAsync(nameof(CarritoPage), animate: true);
			}
			else
			{
				await Toast.Make("Por favor seleccione la cantidad usando el boton mas (+)", ToastDuration.Short).Show();
			}
		}

		// Carrito Limpio.
		private void OnCarritoLimpio(object? _, EventArgs e) => Pizza.CantidadDePizza = 0;

		// Carrito item cambiado.
		private void OnItemCarritoCambiado(ModeloPizza p, int cantidad)
		{
			if (p.Nombre == Pizza.Nombre)
			{
				Pizza.CantidadDePizza = cantidad;
			}
		}

		// Carrito item elimina.
		private void OnItemCarritoEliminado(object? _, ModeloPizza p) => OnItemCarritoCambiado(p, 0);

		// Carrito item actualizado.
		private void OnItemCarritoActualizado(object? _, ModeloPizza p) => OnItemCarritoCambiado(p, p.CantidadDePizza);


		// Dispose.
		public void Dispose()
		{
			_carritoViewModel.CarritoLimpio -= OnCarritoLimpio;
			_carritoViewModel.ElementoDelCarritoActualizado -= OnItemCarritoEliminado;
			_carritoViewModel.ElementoDelCarritoActualizado -= OnItemCarritoActualizado;
		}
	}
}
