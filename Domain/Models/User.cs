using Domain.Interfaces;

namespace Domain.Models;

// TEMPLATE PATTERN
public abstract class User(string username, string email)
{
    private List<ISubscriber<User>> notificationSubscribers { get; } = [];
    public string GetUsername() => username;
    public string GetEmail() => email;
    
    public void AddNotificationSubscriber(ISubscriber<User> subscriber)
    {
        notificationSubscribers.Add(subscriber);
    } 
    public void SendNotification()
    {
        foreach (var notification in notificationSubscribers)
        {
           notification.Update(this); 
        }
    }

    public override string ToString()
    {
        return $"{username}";
    }
}