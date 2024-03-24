using Domain.Interfaces;

namespace Domain.Models.Notification;

public class WhatsappNotificationSubscriber<T>: ISubscriber<T>
{
    public void Update(T changed)
    {
        Console.WriteLine($"Sending whatsapp notification: {changed}");
    }
}