using PizzaApp.Models;
namespace PizzaApp.Servicios
{
    public class ServiciosPizza
    {
        // Propiedades.
        private readonly static IEnumerable<ModeloPizza> modeloPizzas = new List<ModeloPizza>
        {
            new ModeloPizza
            {
                Nombre ="Pizza 1",
                Imagen = "pizza1.png",
                Precio = 2500
            },
			new ModeloPizza
			{
				Nombre ="Pizza 2",
				Imagen = "pizza5.png",
				Precio = 3500
			},
			new ModeloPizza
			{
				Nombre ="Pizza 3",
				Imagen = "pizza4.png",
				Precio = 3000
			},
			new ModeloPizza
			{
				Nombre ="Pizza 4",
				Imagen = "pizza3.png",
				Precio = 2000
			},
			new ModeloPizza
			{
				Nombre ="Pizza 5",
				Imagen = "pizza2.png",
				Precio = 1800
			},
			new ModeloPizza
			{
				Nombre ="Pizza 6",
				Imagen = "pizza6.png",
				Precio = 4000
			},
			new ModeloPizza
			{
				Nombre ="Pizza 7",
				Imagen = "pizza7.png",
				Precio = 3600
			},
			new ModeloPizza
			{
				Nombre ="Pizza 8",
				Imagen = "pizza8.png",
				Precio = 2800
			},
			new ModeloPizza
			{
				Nombre ="Pizza 9",
				Imagen = "pizza9.png",
				Precio = 2650
			},
			new ModeloPizza
			{
				Nombre ="Pizza 10",
				Imagen = "pizza10.png",
				Precio = 3750
			}

		};


		// Metodos.

		// Obtener todas las pizzas
		public IEnumerable<ModeloPizza> ObtenerTodasasPizzas() => modeloPizzas;

		// Obtener pizzas populares
		public IEnumerable<ModeloPizza> ObtenerPizzasPopulalres(int contador = 6) => modeloPizzas.OrderBy(p => Guid.NewGuid()).Take(contador);

		// Obtener pizzas por termino de busqueda.
		// verifica si terminoDeBusqueda es nulo o vacio, si es asi devuelve la coleccion completa, y sino hace la busqueda.
		public IEnumerable<ModeloPizza> ObtenerPizzasByParam(string terminoDeBusqueda) => 
			string.IsNullOrWhiteSpace(terminoDeBusqueda) ? modeloPizzas : modeloPizzas.Where(p => p.Nombre.Contains(terminoDeBusqueda, StringComparison.OrdinalIgnoreCase));
		

    }
}
