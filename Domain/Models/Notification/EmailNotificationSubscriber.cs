using Domain.Interfaces;

namespace Domain.Models.Notification;

public class EmailNotificationSubscriber: ISubscriber
{
    public void Update()
    {
        
            Console.WriteLine("Sending email notification");
        
    }
}