namespace Domain.Interfaces;

public interface ISubscriber<in T>
{
    void Update(T changed);
}