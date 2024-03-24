using Domain.Interfaces;

namespace Domain.Models;

public class Thread: IPublisher
{
    private readonly List<Message> _messages = [];
    private readonly List<ISubscriber> _subscribers = [];

    public void AddMessage(Message msg)
    {
        _messages.Add(msg);
        this.Notify();
    }

    public void RemoveMessage(Message msg)
    {
        _messages.Remove(msg);
    }

    public void Subscribe(ISubscriber listener)
    {
        _subscribers.Add(listener);
    }

    public void Unsubscribe(ISubscriber listener)
    {
        _subscribers.Remove(listener);
    }

    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update();
        }
    }
}