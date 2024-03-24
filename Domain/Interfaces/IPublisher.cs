namespace Domain.Interfaces;

public interface IPublisher<out T>
{
    public void Subscribe(ISubscriber<T> listener);
    public void Unsubscribe(ISubscriber<T> listener);
    public void Notify();
}