using Domain.Interfaces;

namespace Domain.Models;

// TEMPLATE PATTERN
public abstract class User(string username, string email)
{
    private ISubscriber<Message>? _msgNotfier;
    
    public void SetMsgNotifier(ISubscriber<Message>? msgNotifier)
    {
        _msgNotfier = msgNotifier;
    }
    
    public void SendNotification(Message msg)
    {
        _msgNotfier?.Update(msg);
    }
    
    public string GetUsername() => username;
    public string GetEmail() => email;
    
    public override string ToString()
    {
        return $"{username}";
    }
}