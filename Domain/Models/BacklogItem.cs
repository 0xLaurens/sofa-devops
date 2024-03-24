using Domain.Activity;
using Domain.Interfaces;
using Domain.Models.UserRoles;

namespace Domain.Models;

public class BacklogItem : IBacklogItemContext
{
    private List<Activity> _activities = new();
    private List<Thread> _threads = [];
    private IBacklogItemState _state;
    private IBacklogItemState _previousState;

    public void AddActivity(Activity activity)
    {
        _activities.Add(activity);
    }

    public void RemoveActivity(Activity activity)
    {
        _activities.Remove(activity);
    }

    public List<Activity> GetActivities()
    {
        return _activities;
    }

    public void AddTread(Thread thread)
    {
        _threads.Add(thread);
    }

    public void RemoveThread(Thread thread)
    {
        _threads.Remove(thread);
    }

    public void SetState(IBacklogItemState state, User user)
    {
        if (GetPreviousState().GetType() == typeof(ActivityTestedState) && user.GetType() != typeof(LeadDeveloper))
        {
            throw new InvalidOperationException("Only Lead Developer can approve the tested phase.");
        }
        
        _previousState = _state;
        _state = state;
    }

    public IBacklogItemState GetState()
    {
        return _state;
    }

    public IBacklogItemState GetPreviousState()
    {
        return _previousState;
    }
}