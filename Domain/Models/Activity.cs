using Domain.Activity;
using Domain.Interfaces;

namespace Domain.Models;

public class Activity : IActivityContext, IPublisher<IActivityContext>
{
    private IActivityState _state;
    private List<ISubscriber<IActivityContext>> _subscribers = [];
    
    public void SetState(IActivityState state)
    {
        _state = state;
        this.Notify();
    }

    public IActivityState GetState()
    {
        return _state;
    }

    public void Subscribe(ISubscriber<IActivityContext> listener)
    {
        _subscribers.Add(listener);
    }

    public void Unsubscribe(ISubscriber<IActivityContext> listener)
    {
        _subscribers.Remove(listener);
    }

    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(this);
        }
    }

    public override string ToString()
    {
        return $"Activity in state: {_state}";
    }
}