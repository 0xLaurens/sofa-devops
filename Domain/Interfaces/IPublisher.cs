namespace Domain.Interfaces;

public interface IPublisher
{
    void Subscribe(ISubscriber listener);
    void Unsubscribe(ISubscriber listener);
    void Notify();
}