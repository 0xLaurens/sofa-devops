using Domain.Activity;
using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItem
{
    private string _description;
    private List<Activity> _activities;
    private List<Thread> _threads = [];

    public BacklogItem(string description)
    {
        this._activities = new List<IActivityContext>();
        this._description = description;
    }
    
    public BacklogItemState GetState()
    {
        // Dictionary to map IActivityState to BacklogItemState
        var stateMap = new Dictionary<Type, BacklogItemState>
        {
            { typeof(ActivityTodoState), BacklogItemState.Todo },
            { typeof(ActivityDoingState), BacklogItemState.Doing },
            { typeof(ActivityReadyForTestingState), BacklogItemState.Ready },
            { typeof(ActivityTestingState), BacklogItemState.Testing },
            { typeof(ActivityTestedState), BacklogItemState.Tested },
            { typeof(ActivityDoneState), BacklogItemState.Done }
        };
        
        foreach (BacklogItemState state in Enum.GetValues(typeof(BacklogItemState)))
        {
            if (_activities.Any(activity => stateMap[activity.GetState().GetType()] == state))
                return state;
        }
       
        return BacklogItemState.Done;
    }

    public void AddActivity(Activity activity)
    {
        _activities.Add(activity);
    } 
    
    public void RemoveActivity(Activity activity)
    {
        _activities.Remove(activity);
    }

    public void AddTread(Thread thread)
    {
        _threads.Add(thread);
    }

    public void RemoveThread(Thread thread)
    {
        _threads.Remove(thread);
    }
}