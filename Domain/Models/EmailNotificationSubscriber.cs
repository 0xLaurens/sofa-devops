using Domain.Interfaces;

namespace Domain.Models;

public class EmailNotificationSubscriber: ISubscriber
{
    public void Update()
    {
        
            Console.WriteLine("Sending email notification");
        
    }
}