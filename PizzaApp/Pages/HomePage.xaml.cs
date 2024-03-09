namespace PizzaApp.Pages;

public partial class HomePage : ContentPage
{
    // Propiedades.
    private readonly HomeViewModel HomeViewModels;


    // Constructor.
    public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		HomeViewModels = homeViewModel;
		BindingContext = HomeViewModels;
	}
}