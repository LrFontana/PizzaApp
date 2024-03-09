using CommunityToolkit.Mvvm.ComponentModel;

namespace PizzaApp.Models
{
    public partial class ModeloPizza : ObservableObject
    {
        // Propiedades.
        public string? Nombre { get; set; }
        public string? Imagen { get; set; }
        public double Precio { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
        private int _cantidadDePizza;

        public double Total => CantidadDePizza * Precio;
        public ModeloPizza Clone() => MemberwiseClone() as ModeloPizza;

	}
}
