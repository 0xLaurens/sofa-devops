using Domain.Notification;

namespace Domain;

public class Thread: IPublisher
{
    private List<Message> _messages;
    private List<ISubscriber> _subscribers;

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifySubscriber()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update();
        }
    }

    public void AddMessage(Message message)
    {
        _messages.Add(message);
        NotifySubscriber();
    }
}