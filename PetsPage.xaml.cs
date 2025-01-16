using CabinetVeterinar.Models;

namespace CabinetVeterinar;

public partial class PetsPage : ContentPage
{
	public PetsPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        petsListView.ItemsSource = await App.Database.GetPetsAsync();
    }

    async void OnAddPetClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetDetailPage
        {
            BindingContext = new Pet()
        });
    }

    async void OnPetSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var selectedPet = e.SelectedItem as Pet;
            await Navigation.PushAsync(new ProgramariPage(selectedPet));
        }
    }

}