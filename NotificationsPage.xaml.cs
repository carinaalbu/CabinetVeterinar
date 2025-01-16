using Plugin.LocalNotification;
using System.Collections.ObjectModel;

namespace CabinetVeterinar;

public partial class NotificationsPage : ContentPage
{
    public ObservableCollection<NotificationRequest> Notifications { get; set; }
    public NotificationsPage()
	{
		InitializeComponent();
        Notifications = new ObservableCollection<NotificationRequest>();
        notificationsListView.ItemsSource = Notifications;
    }
    public void AddNotification(NotificationRequest notification)
    {
        Notifications.Add(notification);
    }
}