using Domain.Activity;
using Domain.Notification;
using Domain.Sprint;

namespace Domain;

public class BacklogItem: IPublisher
{
    // TODO: consider visitor pattern to check the activity their status to change the parents status. 
    private IVisitor _visitor;
    private List<Activity.Activity> _activities;
    private List<Thread> _threads;
    private List<ISubscriber> _subscribers;

    
    //TODO: visitor pattern should combine the states of the different activities.
    public IActivityState GetState()
    {
        foreach (var activity in _activities)
        {
            _visitor.Visit(activity);     
        }

        return new ActivityDoingState();
    }

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
}