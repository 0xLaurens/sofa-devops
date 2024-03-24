using Domain.Activity;
using Domain.Interfaces;
using Domain.Models.UserRoles;

namespace Domain.Models;

public class BacklogItem : IBacklogItemContext
{
    private readonly List<Activity> _activities = [];
    private readonly List<Thread> _threads = [];
    private IBacklogItemState _state;
    private IBacklogItemState? _previousState;
    private User? _approver;

    protected BacklogItem()
    {
        _state = new BacklogItemTodoState(this);
    }

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

    public void SetState(IBacklogItemState state)
    {
        _previousState = _state;
        _state = state;
    }

    public IBacklogItemState GetState()
    {
        return _state;
    }

    public IBacklogItemState? GetPreviousState()
    {
        return _previousState;
    }

    public void SetApprover(User user)
    {
        _approver = user;
    }

    public User GetApprover()
    {
        if (_approver is null)
        {
            throw new Exception("Approver is not set.");
        }

        return _approver;
    }
}