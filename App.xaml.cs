using System;
using CabinetVeterinar.Data;
using System.IO;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;

namespace CabinetVeterinar
{
    public partial class App : Application
    {
        static ProgramariDatabase database;
        public static ProgramariDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ProgramariDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programari.db3"));
                }
                return database;
            }
        }
        private NotificationsPage _notificationsPage;
        public App()
        {
            InitializeComponent();
            // Configurează notificările locale
            LocalNotificationCenter.Current.NotificationReceived += OnNotificationReceived;

            _notificationsPage = new NotificationsPage();

            // Configurează notificările locale
            LocalNotificationCenter.Current.NotificationReceived += OnNotificationReceived;

            MainPage = new AppShell();
        }

        private void OnNotificationReceived(NotificationEventArgs e)
        {
            // Acest cod va rula când notificarea este primită
            Console.WriteLine($"Notificare primită: {e.Request.Title}");
            //Adaugă notificarea la pagina notificărilor
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _notificationsPage.AddNotification(e.Request);
            });
        }
    }
}
