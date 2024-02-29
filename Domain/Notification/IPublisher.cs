namespace Domain.Notification;

public interface IPublisher
{
    public void Subscribe(ISubscriber subscriber);

    public void Unsubscribe(ISubscriber subscriber);

    public void NotifySubscriber();
}