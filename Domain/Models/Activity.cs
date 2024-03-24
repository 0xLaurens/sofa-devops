using Domain.Activity;
using Domain.Interfaces;

namespace Domain.Models;

public class Activity : IActivityContext, IPublisher<IActivityContext>
{
    private IActivityState _state;
    private List<ISubscriber<IActivityContext>> _subscribers = [];
    private string _description;
    private User _worker;
    private BacklogItem _backlogItem;

    public Activity(string description, User worker, BacklogItem backlogItem)
    {
        _description = description;
        _backlogItem = backlogItem;
        if (_backlogItem.GetActivities().Any(activity => activity.GetUser().GetUsername() == worker.GetUsername()))
        {
            Console.WriteLine("Sending notification to scrum master");
            Notify();
        }
        _worker = worker;
    }

    public void SetState(IActivityState state)
    {
        _state = state;
        this.Notify();

        if (_backlogItem.GetActivities()
            .All(x => x.GetState().GetType() == typeof(Domain.Activity.ActivityReadyForTestingState)) && _backlogItem.GetActivities().Count > 1)
        {
            this.Notify();
        }
    }


    public BacklogItem GetBacklogItem()
    {
        return _backlogItem;
    }


    public User GetUser()
    {
        return _worker;
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