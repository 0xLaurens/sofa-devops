using Domain.Interfaces;

namespace Domain.Models.Notification;

public class EmailNotificationSubscriber<T> : ISubscriber<T>
{
    public void Update(T changed)
    {
        Console.WriteLine($"Sending email notification: {changed}");
    }
}