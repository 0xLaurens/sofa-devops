using Domain.Interfaces;

namespace Domain.Models;

public class Thread : IPublisher<Message>
{
    private readonly List<Message> _messages = [];
    private readonly List<ISubscriber<Message>> _subscribers = [];

    public void AddMessage(Message msg)
    {
        _messages.Add(msg);
        Notify();
    }

    public void RemoveMessage(Message msg)
    {
        _messages.Remove(msg);
    }

    public void Subscribe(ISubscriber<Message> listener)
    {
        _subscribers.Add(listener);
    }

    public void Unsubscribe(ISubscriber<Message> listener)
    {
        _subscribers.Remove(listener);
    }

    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(_messages.Last());
        }
    }
}