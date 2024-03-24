namespace Domain.Interfaces;

public interface IPublisher<out T>
{
    void Subscribe(ISubscriber<T> listener);
    void Unsubscribe(ISubscriber<T> listener);
    void Notify();
}