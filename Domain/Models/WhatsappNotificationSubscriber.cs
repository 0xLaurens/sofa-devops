using Domain.Interfaces;

namespace Domain.Models;

public class WhatsappNotificationSubscriber: ISubscriber
{
    public void Update()
    {
        
        Console.WriteLine("Sending whatsapp notification");
        
    }
}