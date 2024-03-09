namespace PizzaApp
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(CarritoPage), typeof(CarritoPage));
			Routing.RegisterRoute(nameof(CerrarPagina), typeof(CerrarPagina));
		}
	}
}
