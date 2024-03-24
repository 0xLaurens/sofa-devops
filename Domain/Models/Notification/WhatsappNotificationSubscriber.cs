using Domain.Interfaces;

namespace Domain.Models.Notification;

public class WhatsappNotificationSubscriber: ISubscriber
{
    public void Update()
    {
        Console.WriteLine("Sending whatsapp notification");
    }
}