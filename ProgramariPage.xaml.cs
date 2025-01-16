using CabinetVeterinar.Models;

namespace CabinetVeterinar;

public partial class ProgramariPage : ContentPage
{
    private Pet _selectedPet;
    public ProgramariPage()
	{
		InitializeComponent();
	}
    public ProgramariPage(Pet selectedPet)
    {
        InitializeComponent();

        // Stochează animalul selectat pentru utilizare ulterioară
        _selectedPet = selectedPet;

        // Actualizează BindingContext pentru a afișa informațiile animalului
        BindingContext = _selectedPet;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        appointmentsListView.ItemsSource = await App.Database.GetAppointmentsAsync();
        if (_selectedPet != null)
        {
            Console.WriteLine($"Programări pentru {_selectedPet.Name}");
        }
    }

    async void OnAddAppointmentClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramariDetailPage
        {
            BindingContext = new Programari()
        });
    }

    async void OnAppointmentSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProgramariDetailPage
            {
                BindingContext = e.SelectedItem as Programari
            });
        }
    }
    async void OnPetSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var selectedPet = e.SelectedItem as Pet;

            // Navighează la ProgramariPage cu animalul selectat
            await Navigation.PushAsync(new ProgramariPage(selectedPet));
        }
    }

}