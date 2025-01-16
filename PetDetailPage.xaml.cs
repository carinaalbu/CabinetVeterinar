using System;
using CabinetVeterinar.Models;
using Microsoft.Maui.Controls;

namespace CabinetVeterinar;

public partial class PetDetailPage : ContentPage
{
	public PetDetailPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var pet = (Pet)BindingContext;

        // Salvează datele animalului în baza de date
        await App.Database.SavePetAsync(pet);

        // Navighează înapoi la pagina anterioară
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var pet = (Pet)BindingContext;

        // Șterge animalul din baza de date
        await App.Database.DeletePetAsync(pet);

        // Navighează înapoi la pagina anterioară
        await Navigation.PopAsync();
    }

    async void OnAddPetClicked(object sender, EventArgs e)
    {
        // Navighează la pagina de detalii pentru un nou animal
        await Navigation.PushAsync(new PetDetailPage
        {
            BindingContext = new Pet()
        });
    }

    async void OnPetSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            // Navighează la pagina de detalii pentru un animal selectat
            await Navigation.PushAsync(new PetDetailPage
            {
                BindingContext = e.SelectedItem as Pet
            });
        }
    }

}