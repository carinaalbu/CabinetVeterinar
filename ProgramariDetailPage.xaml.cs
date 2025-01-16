using CabinetVeterinar.Models;


namespace CabinetVeterinar;

public partial class ProgramariDetailPage : ContentPage
{
	public ProgramariDetailPage()
	{
		InitializeComponent();
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {
        var appointment = (Programari)BindingContext;
        await App.Database.SaveAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var appointment = (Programari)BindingContext;
        await App.Database.DeleteAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var programare = (Programari)BindingContext;
        programare.AppointmentDate = DateTime.UtcNow; // Exemplu: setează ora curentă pentru test

        await App.Database.SaveAppointmentAsync(programare);
        // Creează un obiect Appointment pentru notificare
        var appointmentForNotification = new Appointment
        {
            ID = programare.ID, // Folosește ID-ul din Programari
            AppointmentDate = programare.AppointmentDate,
            Pet = null // Dacă există o asociere
        };

        // Programează notificarea pentru această programare
        App.Database.ScheduleNotificationForAppointment(appointmentForNotification);

        await Navigation.PopAsync();
    }

}