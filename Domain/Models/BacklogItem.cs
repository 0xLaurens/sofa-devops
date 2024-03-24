using Domain.Activity;
using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItem
{
    // TODO: consider visitor pattern to check the activity their status to change the parents status. 

    private List<IActivityContext> _activities;
    private List<Thread> _threads;
    private string _description;

    public BacklogItem(string description)
    {
        this._activities = new List<IActivityContext>();
        this._description = description;
    }


    
    public BacklogItemState GetState()
    {
        // Dictionary to map IActivityState to BacklogItemState
        Dictionary<Type, BacklogItemState> stateMap = new Dictionary<Type, BacklogItemState>
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

       

        // If no activity is found, return the default state (Done)
        return BacklogItemState.Done;
    }

    public List<IActivityContext> getActivities()
    {
        return _activities;
    }

    public void AddActivity(IActivityContext activity)
    {
        _activities.Add(activity);
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